﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    public class BbFeedReadJob : IJob
    {
        private FeedScraper processor;
        private ApiWrapper couponRepository;
        private UnityContainer container;

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                container = (UnityContainer)context.MergedJobDataMap["unityContainer"];

                processor = new FeedScraper(new ChromeDriver(GlobalConstants.ChromeDriverPath));
                couponRepository = container.Resolve<ApiWrapper>();

                context.RescheduleJob(65, 80);

                using (processor)
                {
                    List<Coupon> coupons = processor.GetValuableCoupons(GlobalConstants.Url).ToList();

                    couponRepository.AddCouponsToPlay(coupons);
                }
            }
            catch (JobExecutionException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
