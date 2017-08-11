using System;
using System.Collections.Generic;
using System.Linq;
using BetReader.Constans;
using BetReader.DataAccess.Database.Repositores;
using BetReader.Domain.Entities;
using BetReader.Domain.Readers;
using BetReader.Domain.Readers.BbRead;
using BetReader.Domain.Readers.Interfaces;
using Microsoft.Practices.Unity;
using NLog;
using OpenQA.Selenium.Chrome;
using Quartz;

namespace BetReader.Service.Core.Jobs
{
    public class BbFeedReadJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Settings settings = (Settings)context.MergedJobDataMap["settings"];
            try
            {
                UnityContainer container = (UnityContainer)context.MergedJobDataMap["unityContainer"];
                
                var reader = new BbCouponReader(new ChromeDriver(GlobalConstants.ChromeDriverPath), GlobalConstants.LiveBbUrl);
                var couponRepo = container.Resolve<ICouponRepository>();

                using (reader)
                {
                    List<Coupon> coupons = reader.GetAll(0.05, 50).ToList();
                    LogManager.GetLogger("main").Info($"{coupons.Count} valuable coupons were read.");

                    couponRepo.CreateBulk(coupons);
                }
            }
            catch (Exception ex)
            {
                var logger = LogManager.GetLogger("errors");
                logger.Info($"Exception : {ex}");
                throw;
            }
            context.RescheduleJob(settings.ReadMinInterval, settings.ReadMaxInterval);
        }

    }
}
