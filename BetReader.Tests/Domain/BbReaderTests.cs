using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BetReader.Constans;
using BetReader.Domain.Entities;
using BetReader.Domain.Readers;
using BetReader.Domain.Readers.BbRead;
using BetReader.Domain.Readers.Interfaces;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using CollectionAssert = NUnit.Framework.CollectionAssert;

namespace BetReader.Tests.Domain
{
    public class BbReaderTests
    {
        private ICouponReader feedScraper;
        private const string CouponFilePath = "C:/projects/BetReader/TestSiteBb/expected-coupons.txt";

        [OneTimeSetUp]
        public void Setup()
        {
            feedScraper = new BbCouponReader(new ChromeDriver(GlobalConstants.ChromeDriverPath), GlobalConstants.LocalBbUrl);
            //feedScraper = new FeedScraper(new PhantomJSDriver(GlobalConstants.PhantomDriverPath));
        }

        [Test]
        public void GetAllCouponsTest()
        {
            var actualCoupons = feedScraper.GetAll(0, 0); //.ToList()

//            var serialized = JsonConvert.SerializeObject(actualCoupons);
//            File.WriteAllText(CouponFilePath, serialized);

            var expectedCouponsJson = File.ReadAllText(CouponFilePath, Encoding.UTF8);
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
