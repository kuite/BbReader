using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetReader.Constans;
using BetReader.Model.Entities;
using BetReader.Scraper.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BetReader.Tests.Core
{
    [TestClass]
    public class FeedScraperTests
    {
        private FeedScraper feedScraper;
        private string couponFilePath = "C:/projects/BetReader/TestSiteBb/feed.txt";

        [SetUp]
        public void Setup()
        {
            feedScraper = new FeedScraper(new ChromeDriver(GlobalConstants.ChromeDriverPath));
        }

        [Test]
        public void GetValuableCouponsTest()
        {
            var actualCoupons = feedScraper.GetValuableCoupons(GlobalConstants.LocalBbUrl).Take(5).ToList();
            JArray actualJarray = (JArray) JToken.FromObject(actualCoupons);

            var expectedCoupons = File.ReadAllText(couponFilePath, Encoding.UTF8);
            var expectedJson = JsonConvert.SerializeObject(expectedCoupons);
            JArray expectedJarray = JArray.Parse(expectedJson);

            Assert.AreEqual(expectedJarray, actualJarray);
        }

        [Test]
        public void AmountOfCouponsTest()
        {
            var actualCouponsCount = feedScraper.GetValuableCoupons(GlobalConstants.Url).Count();
            bool isCountValid = actualCouponsCount > 15;
            Assert.AreEqual(true, isCountValid);
        }

        [Test]
        [TestCase(GlobalConstants.Url)]
        [TestCase(GlobalConstants.LocalBbUrl)]
        public void CouponsFieldsTest(string sourcePath)
        {
            var actualCoupons = feedScraper.GetValuableCoupons(sourcePath);
            foreach (var coupon in actualCoupons)
            {
                var isAuthorValid = coupon.Author.Length > 0;
                var isUrlValid = coupon.CouponUrl.StartsWith("https://")
                                 && coupon.CouponUrl.Contains("blogabet.com/pick");
                var isStakeValid = coupon.AuthorsStake >= 0 && coupon.AuthorsStake <= 10;
                var isCouponValid = isAuthorValid && isUrlValid && isStakeValid;
                Assert.AreEqual(true, isCouponValid);
            }
        }
    }
}
