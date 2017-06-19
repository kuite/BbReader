using System.Collections.Generic;
using System.IO;
using System.Text;
using BetReader.Model.Entities;
using BetReader.Scraper.Core;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BetReader.Tests.Scraper
{
    [TestClass]
    public class FeedResolverTests
    {
        private FeedResolver resolver;
        private string couponsFilePath = "C:/projects/BetReader/TestSiteBb/unresolved-coupons.txt";
        private int expectedWonCoupons = 1;
        private int expectedLostCoupons = 1;

        [SetUp]
        public void SetUp()
        {
            resolver = new FeedResolver(new HtmlWeb());
        }

        [Test]
        public void ResolveCouponsTest()
        {
            var wonCoupons = 0;
            var lostCoupons = 0;
            var unresolvedContent = File.ReadAllText(couponsFilePath, Encoding.UTF8);
            var unresolvedCoupons = JsonConvert.DeserializeObject<List<Coupon>>(unresolvedContent);

            var resolvedCoupons = resolver.ResolveCoupons(unresolvedCoupons);
            foreach (var coupon in resolvedCoupons)
            {
                if (coupon.IsWon)
                {
                    wonCoupons = wonCoupons + 1;
                }
                else
                {
                    lostCoupons = lostCoupons + 1;
                }
            }

            Assert.AreEqual(wonCoupons, expectedWonCoupons);
            Assert.AreEqual(lostCoupons, expectedLostCoupons);
        }
    }
}
