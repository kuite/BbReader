using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betreader.DataAccess.Database;
using BetReader.DataAccess.Database.Repositores;
using BetReader.Domain.Entities;
using Effort;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BetReader.Tests.DataAccess
{
    public class CouponRepositoryTest
    {
        private ICouponRepository couponRepo;

        [OneTimeSetUp]
        public void Setup()
        {
            var readerContextMock = new Mock<BetReaderContext>();
            var couponsMock = new Mock<DbSet<Coupon>>();
            var coupons = new List<Coupon>();

            var atr1 = new Author
            {
                Name = "typer1",
                PicksCount = 100,
                Yield = 0.06
            };

            var atr2 = new Author
            {
                Name = "typer2",
                PicksCount = 120,
                Yield = 0.09
            };

            var atr3 = new Author
            {
                Name = "typer3",
                PicksCount = 130,
                Yield = 0.33
            };

            var coupon1 = new Coupon
            {
                Author = atr1,
                CreatedAtSource = DateTime.ParseExact("30.04.2017 22:35:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Odds = 1.9,
                Description = "coupon1",
                CouponUrl = "https://acor85.blogabet.com/pick/16789551/nice-v-psg",
            };

            var pick1 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 1.9,
                Event = "Nice v PSG",
                Selection = "Nice v PSG",
                SportType = "Football / Livebet",
                Coupon = coupon1
            };
            coupon1.Picks.Add(pick1);

            var coupon2 = new Coupon
            {
                Author = atr2,
                CreatedAtSource = DateTime.ParseExact("30.04.2017 22:57:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Odds = 2.37,
                Description = "coupon2",
                CouponUrl = "https://stoguardandosolo.blogabet.com/pick/16789543/gerald-melzer-yannick-hanfmann",
            };

            var pick2 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 2.37,
                Event = "Gerald Melzer - Yannick Hanfmann",
                Selection = "Gerald Melzer - Yannick Hanfmann",
                SportType = "Tennis / ATP",
                Coupon = coupon2
            };
            coupon2.Picks.Add(pick2);

            var coupon3 = new Coupon
            {
                Author = atr3,
                CreatedAtSource = DateTime.ParseExact("30.04.2017 22:42:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Odds = 3.5,
                Description = "coupon3",
                CouponUrl = "https://mastersanti.blogabet.com/pick/16785974/washington-nationals-new-york-mets"
            };

            var pick3 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 3.5,
                Event = "Washington Nationals - New York Mets",
                Selection = "Washington Nationals - New York Mets",
                SportType = "Baseball / MLB",
                Coupon = coupon3
            };
            coupon3.Picks.Add(pick3);

            coupons.Add(coupon1);
            coupons.Add(coupon2);
            coupons.Add(coupon3);

            var connection = DbConnectionFactory.CreateTransient();
            var ctx = new BetReaderContext(connection);
            ctx.Coupons.AddRange(coupons);
            ctx.SaveChanges();
            couponRepo = new CouponRepository(ctx);
        }

        [Test]
        public void CreateBulkTest()
        {
            //            var actualCoupons = feedScraper.GetAll(); //.ToList()
            //
            //            //            var serialized = JsonConvert.SerializeObject(actualCoupons);
            //            //            File.WriteAllText(CouponFilePath, serialized);
            //
            //            var expectedCouponsJson = File.ReadAllText(CouponFilePath, Encoding.UTF8);
            //            List<Coupon> expectedCoupons = JsonConvert.DeserializeObject<List<Coupon>>(expectedCouponsJson);

            List<Coupon> coupons = couponRepo.GetAll().ToList();

            CollectionAssert.AreEqual(coupons, coupons);
        }
    }
}
