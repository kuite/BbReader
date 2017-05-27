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
            Assert.AreEqual(actualCouponsCount, 20);
        }
    }
}
