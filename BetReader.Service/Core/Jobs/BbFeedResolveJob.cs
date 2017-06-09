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
        private IDataProvider apiWrapper;
        private UnityContainer container;

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                container = (UnityContainer)context.MergedJobDataMap["unityContainer"];

                resolver = new FeedResolver(new HtmlWeb());
                apiWrapper = container.Resolve<IDataProvider>();

                context.RescheduleJob(59, 60);

                List<Coupon> couponsInPlay = apiWrapper.GetCouponsInPlay();
                List<Coupon> resolvedCoupons = resolver.ResolveCoupons(couponsInPlay).ToList();

                apiWrapper.UpdateCoupons(resolvedCoupons);
            }
            catch (JobExecutionException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
