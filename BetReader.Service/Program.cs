using System;
using System.Collections.Generic;
using Betreader.DataAccess.Database;
using BetReader.DataAccess.Database.Repositores;
using BetReader.Domain.Readers.BbRead;
using BetReader.Service.Core.Jobs;
using Microsoft.Practices.Unity;
using NLog;
using Quartz;
using Quartz.Impl;

namespace BetReader.Service
{
    public class Settings
    {
        public int ReadMinInterval { get; set; } = 60;
        public int ReadMaxInterval { get; set; } = 100;
        public int ResolveMinInterval { get; set; } = 60;
        public int ResolveMaxInterval { get; set; } = 100;
        public int MinCouponsCount { get; set; } = 50;
        public double MinYield { get; set; } = 0.05;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var settings = new Settings();
            var container = new UnityContainer();
            var rnd = new Random();

            container.RegisterType<BbCouponReader, BbCouponReader>();
            container.RegisterType<BbFeedReadJob, BbFeedReadJob>();
            container.RegisterType<ICouponRepository, CouponRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<BetReaderContext>(new InjectionConstructor());

//            while (true)
//            {
//                var reader = new BbCouponReader(new ChromeDriver(GlobalConstants.ChromeDriverPath), GlobalConstants.LiveBbUrl);
//                var couponRepo = container.Resolve<ICouponRepository>();
//
//                using (reader)
//                {
//                    List<Coupon> coupons = reader.GetAll(0, 0).ToList();
//                    LogManager.GetLogger("main").Info($"{coupons.Count} valuable coupons were read.");
//
//                    couponRepo.CreateBulk(coupons);
//                }
//
//                var wait = new Random().Next(10, 35);
//                wait = 20;
//                Thread.Sleep(new TimeSpan(0, 0, wait));
//            }


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
            //jobs.Add(JobBuilder.Create<BbFeedResolveJob>().Build());

            int counter = 1;
            foreach (IJobDetail job in jobs)
            {
                try
                {
                    var triggerName = "job" + counter;
                    job.JobDataMap["rnd"] = rnd;
                    job.JobDataMap["unityContainer"] = container;
                    job.JobDataMap["triggerKey"] = triggerName;
                    job.JobDataMap["settings"] = settings;

                    ITrigger trigger = TriggerBuilder.Create()
                        .WithIdentity(new TriggerKey(triggerName))
                        .StartNow()
                        .Build();

                    sched.ScheduleJob(job, trigger);
                }
                catch (Exception ex)
                {
                    var logger = LogManager.GetLogger("errors");
                    logger.Info($"Exception : {ex}");
                    throw;
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
