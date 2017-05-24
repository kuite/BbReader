using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetReader.Constans;
using BetReader.Model.Entities;
using BetReader.Scraper.Core;
using BetReader.Service.Core.DataAccess;
using HtmlAgilityPack;
using Microsoft.Practices.Unity;
using OpenQA.Selenium.Chrome;
using Quartz;

namespace BetReader.Service.Core.Jobs
{
    public class BbFeedResolveJob : IJob
    {
        private FeedResolver resolver;
        private CouponRepository couponRepository;
        private UnityContainer container;

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                container = (UnityContainer)context.MergedJobDataMap["unityContainer"];

                resolver = new FeedResolver(new HtmlWeb());
                couponRepository = container.Resolve<CouponRepository>();

                context.RescheduleJob(59, 60);

                var couponsInPlay = couponRepository.GetAll().Where(c =>
                    c.IsPlayed &&
                    c.IsResolved == false).ToList();
                var resolvedCoupons = resolver.ResolveCoupons(couponsInPlay).ToList();

                resolvedCoupons.ForEach(c => couponRepository.Update(c));
                couponRepository.SaveChanges();

            }
            catch (JobExecutionException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
