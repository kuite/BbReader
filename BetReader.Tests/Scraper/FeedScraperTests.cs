using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BetReader.Constans;
using BetReader.Model.Entities;
using BetReader.Scraper.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;

namespace BetReader.Tests.Scraper
{
    [TestClass]
    public class FeedScraperTests
    {
        private FeedScraper feedScraper;
        private string couponFilePath = "C:/projects/BetReader/TestSiteBb/expected-coupons.txt";

        [OneTimeSetUp]
        public void Setup()
        {
            feedScraper = new FeedScraper(new ChromeDriver(GlobalConstants.ChromeDriverPath));
            //feedScraper = new FeedScraper(new PhantomJSDriver(GlobalConstants.PhantomDriverPath));
        }

        [Test]
        public void GetValuableCouponsTest()
        {
            var actualCoupons = feedScraper.GetValuableCoupons(GlobalConstants.LocalBbUrl).ToList();

            var expectedCouponsJson = File.ReadAllText(couponFilePath, Encoding.UTF8);
            List<Coupon> expectedCoupons = JsonConvert.DeserializeObject<List<Coupon>>(expectedCouponsJson);

            CollectionAssert.AreEqual(expectedCoupons, actualCoupons);
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            feedScraper.Dispose();
        }
    }
}
