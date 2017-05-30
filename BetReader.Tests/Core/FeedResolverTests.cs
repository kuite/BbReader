using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetReader.Api.Models.Database;
using BetReader.Api.Models.Repositores;
using BetReader.Scraper.Core;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace BetReader.Tests.Core
{
    [TestClass]
    public class FeedResolverTests
    {
        private FeedResolver resolver;
        private CouponRepository couponRepository;

        [SetUp]
        public void SetUp()
        {
            resolver = new FeedResolver(new HtmlWeb());
            couponRepository = new CouponRepository(new BetReaderContext());
        }

        [Test]
        public void ResolveCouponsTest()
        {
            var unresolvedCoupons = couponRepository.GetAll().Where(c =>
                    c.IsResolved == false).ToList();

            var resolvedCoupons = resolver.ResolveCoupons(unresolvedCoupons);
        }
    }
}
