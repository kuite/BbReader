using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetReader.Api.Models.Database;
using BetReader.Api.Models.Repositores;
using BetReader.Model.Entities;
using BetReader.Scraper.Core;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BetReader.Tests.Core
{
    [TestClass]
    public class FeedResolverTests
    {
        private FeedResolver resolver;

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
            var unresolvedText = File.ReadAllText("", Encoding.UTF8); //"C:/projects/BetReader/TestSiteBb/coupons.txt"
            var unresolvedCoupons = JsonConvert.DeserializeObject<List<Coupon>>(unresolvedText);

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

            Assert.AreEqual(wonCoupons, 1);
            Assert.AreEqual(lostCoupons, 1);
        }
    }
}
