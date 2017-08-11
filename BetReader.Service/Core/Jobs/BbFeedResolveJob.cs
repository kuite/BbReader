using System.Collections.Generic;
using System.Linq;
using BetReader.DataAccess.Database.Repositores;
using BetReader.Domain.Entities;
using BetReader.Domain.Resolvers;
using HtmlAgilityPack;
using Microsoft.Practices.Unity;
using NLog;
using Quartz;

namespace BetReader.Service.Core.Jobs
{
    public class BbFeedResolveJob : IJob
    {

        public void Execute(IJobExecutionContext context)
        {
            Settings settings = (Settings)context.MergedJobDataMap["settings"];
            try
            {
                UnityContainer container = (UnityContainer)context.MergedJobDataMap["unityContainer"];

                var resolver = new BbCouponsResolver(new HtmlWeb());
                var couponRepo = container.Resolve<ICouponRepository>();

                context.RescheduleJob(settings.ResolveMinInterval, settings.ResolveMaxInterval);

                List<Coupon> couponsInPlay = couponRepo.GetCouponsInPlay().ToList();
                IEnumerable<Coupon> resolvedCoupons = resolver.ResolveCoupons(couponsInPlay);

                couponRepo.UpdateCoupons(resolvedCoupons);
            }
            catch (JobExecutionException ex)
            {
                var logger = LogManager.GetLogger("errors");
                logger.Info($"Exception : {ex}");
                throw;
            }
        }
    }
}
