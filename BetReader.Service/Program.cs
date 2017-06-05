using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BetReader.Constans;
using BetReader.Model.Entities;
using BetReader.Scraper;
using BetReader.Scraper.Core;
using BetReader.Service.Core.DataAccess;
using BetReader.Service.Core.Jobs;
using HtmlAgilityPack;
using Microsoft.Practices.Unity;
using OpenQA.Selenium.Chrome;
using Quartz;
using Quartz.Impl;

namespace BetReader.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            var rnd = new Random();

            container.RegisterType<FeedScraper, FeedScraper>();
            container.RegisterType<BbFeedReadJob, BbFeedReadJob>();
            container.RegisterType<ApiWrapper, ApiWrapper>(new HierarchicalLifetimeManager());

//                        while (true)
//                        {
//                            var processor = new FeedScraper(new ChromeDriver(GlobalConstants.ChromeDriverPath));
//                            var couponRepository = container.Resolve<CouponRepository>();
//            
//                            using (processor)
//                            {
//                                List<Coupon> coupons = processor.GetValuableCoupons().ToList();
//            
//                                foreach (Coupon coupon in coupons)
//                                {
//                                    couponRepository.CreateSeedToConsole(coupon);
//                                }
//                            }
//            
//                            Thread.Sleep(new TimeSpan(0, 1, 0));
//                        }

            //            while (true)
            //            {
            //                var resolver = new FeedResolver(new HtmlWeb());
            //                var couponRepository = container.Resolve<CouponRepository>();
            //
            //                var couponsInPlay = couponRepository.GetAll().Where(c =>
            //                    c.IsPlayed &&
            //                    c.IsResolved == false).ToList();
            //                var resolvedCoupons = resolver.ResolveCoupons(couponsInPlay).ToList();
            //
            //                resolvedCoupons.ForEach(c => couponRepository.CreateSeedToConsole(c));
            //
            //                Thread.Sleep(new TimeSpan(0, 1, 0));
            //            }


            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = schedFact.GetScheduler();
            sched.Start();

            var jobs = new List<IJobDetail>();
            jobs.Add(JobBuilder.Create<BbFeedReadJob>().Build());
            jobs.Add(JobBuilder.Create<BbFeedResolveJob>().Build());

            int counter = 1;
            foreach (IJobDetail job in jobs)
            {
                try
                {
                    var triggerName = "job" + counter;
                    job.JobDataMap["rnd"] = rnd;
                    job.JobDataMap["unityContainer"] = container;
                    job.JobDataMap["triggerKey"] = triggerName;

                    ITrigger trigger = TriggerBuilder.Create()
                        .WithIdentity(new TriggerKey(triggerName))
                        .StartNow()
                        .Build();

                    sched.ScheduleJob(job, trigger);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    counter++;
                }
            }

            Console.ReadKey();
        }
    }
}
