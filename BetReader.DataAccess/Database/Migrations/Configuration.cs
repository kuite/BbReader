using System;
using System.Data.Entity.Migrations;
using System.Collections.Generic;
using System.Globalization;
using BetReader.Domain.Entities;
using BetReader.Domain.Entities.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Betreader.DataAccess.Database.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BetReaderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Database\Migrations";
            ContextKey = "BetReader.DataAccess.Database.BetReaderContext";
        }

        protected override void Seed(BetReaderContext context)
        {
            //  This method will be called after migrating to the latest version.

            #region Seed

            var author1 = new Author
            {
                HomeSite = Source.Blogabet,
                Name = "acor85",
                PicksCount = 147,
                Yield = 0.17
            };

            var coupon1 = new Coupon
            {
                Author = author1,
                CreatedAtSource = DateTime.ParseExact("30.04.2017 22:35:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Odds = 1.9,
                Description = "",
                CouponUrl = "https://acor85.blogabet.com/pick/16789551/nice-v-psg",
            };
            
            var pick11 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 1.9,
                Event = "Nice v PSG",
                Selection = "Nice v PSG",
                SportType = "Football / Livebet",
                Coupon = coupon1
            };
            coupon1.Picks.Add(pick11);
            context.Coupons.AddOrUpdate(coupon1);

            var author2 = new Author
            {
                HomeSite = Source.Blogabet,
                Name = "Game_Bet_Match",
                PicksCount = 147,
                Yield = 0.09
            };

            var coupon2 = new Coupon
            {
                Author = author2,
                CreatedAtSource = DateTime.ParseExact("30.04.2017 22:57:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Odds = 2.37,
                Description = "",
                CouponUrl = "https://stoguardandosolo.blogabet.com/pick/16789543/gerald-melzer-yannick-hanfmann",
            };

            var pick21 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 2.37,
                Event = "Gerald Melzer - Yannick Hanfmann",
                Selection = "Gerald Melzer - Yannick Hanfmann",
                SportType = "Tennis / ATP",
                Coupon = coupon2
            };
            coupon2.Picks.Add(pick21);
            context.Coupons.AddOrUpdate(coupon2);

            var author3 = new Author
            {
                HomeSite = Source.Blogabet,
                Name = "john_anthony",
                PicksCount = 1411,
                Yield = 0.13
            };

            var coupon3 = new Coupon
            {
                Author = author3,
                CreatedAtSource = DateTime.ParseExact("30.04.2017 22:42:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Odds = 3.5,
                Description = "",
                CouponUrl = "https://mastersanti.blogabet.com/pick/16785974/washington-nationals-new-york-mets"
            };
            
            var pick31 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 3.5,
                Event = "Washington Nationals - New York Mets",
                Selection = "Washington Nationals - New York Mets",
                SportType = "Baseball / MLB",
                Coupon = coupon3
            };
            coupon3.Picks.Add(pick31);
            context.Coupons.AddOrUpdate(coupon3);

            var author4 = new Author
            {
                HomeSite = Source.Blogabet,
                Name = "geobet12",
                PicksCount = 94,
                Yield = 0.27
            };

            var coupon4 = new Coupon
            {
                Author = author4,
                CreatedAtSource = DateTime.ParseExact("30.04.2017 22:27:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Odds = 2.63,
                Description = "",
                CouponUrl = "https://geobet12.blogabet.com/pick/16789523/ogc-nice-paris-saint-germain-fc",
            };
            
            var pick41 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 2.63,
                Event = "OGC Nice - Paris Saint-Germain FC",
                Selection = "OGC Nice - Paris Saint-Germain FC",
                SportType = "Football / Livebet",
                Coupon = coupon4
            };
            coupon4.Picks.Add(pick41);
            context.Coupons.AddOrUpdate(coupon4);

            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("polska12");
            context.Users.AddOrUpdate(u => u.UserName,
                new IdentityUser
                {
                    Email = "admin@wp.pl",
                    UserName = "admin@wp.pl",
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString(),
                });

            #endregion

            context.SaveChanges();
        }
    }
}
