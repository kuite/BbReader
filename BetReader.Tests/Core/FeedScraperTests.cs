using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetReader.Model.Entities;
using BetReader.Scraper.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BetReader.Tests.Core
{
    [TestClass]
    public class FeedScraperTests
    {
        private FeedScraper feedScraper;

        [SetUp]
        public void Setup()
        {
            feedScraper = new FeedScraper(new ChromeDriver(@"C:\Users\hitenz\Desktop"));
        }

        [Test]
        public void GetValuableCouponsTest()
        {
            var actualCoupons = feedScraper.GetValuableCoupons().Take(5).ToList();
            var actualJson = JsonConvert.SerializeObject(actualCoupons);

            var expectedCoupons = File.ReadAllText("C:/projects/BetReader/TestSiteBb/feed.txt", Encoding.UTF8);
            var expectedJson = JsonConvert.SerializeObject(expectedCoupons);

            Assert.AreEqual(actualJson, expectedJson);
        }

        [Test]
        public void AmountOfCouponsTest()
        {
            var actualCouponsCount = feedScraper.GetValuableCoupons().Count();
            bool isCountValid = actualCouponsCount > 15;
            Assert.AreEqual(true, isCountValid);
        }

        [Test]
        public void CouponsFieldsTest()
        {
            var actualCoupons = feedScraper.GetValuableCoupons();
            foreach (var coupon in actualCoupons)
            {
                var isAuthorValid = coupon.Author.Length > 0;
                //var isYieldValid = coupon.AuthorsYield >= GlobalConstants.MinimalYield;
                //var isPCountValid = coupon.AuthorsPicksCount >= GlobalConstants.MinimalPicksCount;
                var isUrlValid = coupon.CouponUrl.StartsWith("https://")
                                 && coupon.CouponUrl.Contains("blogabet.com/pick");
                var isStakeValid = coupon.AuthorsStake >= 0 && coupon.AuthorsStake <= 10;
                var isCouponValid = isAuthorValid && isUrlValid && isStakeValid;
                Assert.AreEqual(true, isCouponValid);
            }
        }
    }
}
