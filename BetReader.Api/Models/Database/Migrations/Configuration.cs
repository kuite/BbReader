using System;
using System.Data.Entity.Migrations;
using System.Globalization;
using BetReader.Model.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BetReader.Api.Models.Database.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BetReaderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Models\Database\Migrations";
            ContextKey = "BetReader.Api.Models.Database.BetReaderContext";
        }

        protected override void Seed(BetReaderContext context)
        {
            //  This method will be called after migrating to the latest version.

            #region Seed
            var coupon1 = new Coupon
            {
                Id = 1,
                Author = "acor85",
                AddedTime = DateTime.ParseExact("30.04.2017 22:35:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 147,
                AuthorsYield = 0.17,
                Odds = 1.9,
                Description = "",
                CouponUrl = "https://acor85.blogabet.com/pick/16789551/nice-v-psg",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon1);
            var pick11 = new Pick
            {
                Id = 1,
                KickOff = DateTime.Now,
                Odds = 1.9,
                Event = "Nice v PSG",
                Selection = "Nice v PSG",
                SportType = "Football / Livebet",
                Coupon = coupon1
            };
            context.Picks.AddOrUpdate(pick11);


            var coupon2 = new Coupon
            {
                Id = 2,
                Author = "Game_Bet_Match",
                AddedTime = DateTime.ParseExact("30.04.2017 22:57:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 426,
                AuthorsYield = 0.07,
                Odds = 2.37,
                Description = "",
                CouponUrl = "https://stoguardandosolo.blogabet.com/pick/16789543/gerald-melzer-yannick-hanfmann",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon2);
            var pick21 = new Pick
            {
                Id = 2,
                KickOff = DateTime.Now,
                Odds = 2.37,
                Event = "Gerald Melzer - Yannick Hanfmann",
                Selection = "Gerald Melzer - Yannick Hanfmann",
                SportType = "Tennis / ATP",
                Coupon = coupon2
            };
            context.Picks.AddOrUpdate(pick21);


            var coupon3 = new Coupon
            {
                Id = 3,
                Author = "john_anthony",
                AddedTime = DateTime.ParseExact("30.04.2017 22:42:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 1411,
                AuthorsYield = 0.13,
                Odds = 3.5,
                Description = "",
                CouponUrl = "https://mastersanti.blogabet.com/pick/16785974/washington-nationals-new-york-mets",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon3);
            var pick31 = new Pick
            {
                Id = 3,
                KickOff = DateTime.Now,
                Odds = 3.5,
                Event = "Washington Nationals - New York Mets",
                Selection = "Washington Nationals - New York Mets",
                SportType = "Baseball / MLB",
                Coupon = coupon3
            };
            context.Picks.AddOrUpdate(pick31);


            var coupon4 = new Coupon
            {
                Id = 4,
                Author = "geobet12",
                AddedTime = DateTime.ParseExact("30.04.2017 22:27:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 94,
                AuthorsYield = 0.27,
                Odds = 2.63,
                Description = "",
                CouponUrl = "https://geobet12.blogabet.com/pick/16789523/ogc-nice-paris-saint-germain-fc",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon4);
            var pick41 = new Pick
            {
                Id = 4,
                KickOff = DateTime.Now,
                Odds = 2.63,
                Event = "OGC Nice - Paris Saint-Germain FC",
                Selection = "OGC Nice - Paris Saint-Germain FC",
                SportType = "Football / Livebet",
                Coupon = coupon4
            };
            context.Picks.AddOrUpdate(pick41);


            var coupon5 = new Coupon
            {
                Id = 5,
                Author = "Tri?kster",
                AddedTime = DateTime.ParseExact("30.04.2017 22:37:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 209,
                AuthorsYield = 0.08,
                Odds = 1.909,
                Description = "",
                CouponUrl = "https://probsk.blogabet.com/pick/16789514/ferro-caba-ciclista-olimpico",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon5);
            var pick51 = new Pick
            {
                Id = 5,
                KickOff = DateTime.Now,
                Odds = 1.909,
                Event = "Ferro Caba - Ciclista Olimpico",
                Selection = "Ferro Caba - Ciclista Olimpico",
                SportType = "Basketball / Argentina",
                Coupon = coupon5
            };
            context.Picks.AddOrUpdate(pick51);


            var coupon6 = new Coupon
            {
                Id = 6,
                Author = "USAMLS",
                AddedTime = DateTime.ParseExact("30.04.2017 22:57:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 662,
                AuthorsYield = 0.11,
                Odds = 6.3,
                Description = "",
                CouponUrl = "https://usamls.blogabet.com/pick/16789505/atlanta-united-washington-dc-united",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon6);
            var pick61 = new Pick
            {
                Id = 6,
                KickOff = DateTime.Now,
                Odds = 6.3,
                Event = "Atlanta United - Washington DC United",
                Selection = "Atlanta United - Washington DC United",
                SportType = "Football / Livebet",
                Coupon = coupon6
            };
            context.Picks.AddOrUpdate(pick61);


            var coupon7 = new Coupon
            {
                Id = 7,
                Author = "USAMLS",
                AddedTime = DateTime.ParseExact("30.04.2017 22:48:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 662,
                AuthorsYield = 0.11,
                Odds = 2.01,
                Description = "",
                CouponUrl = "https://usamls.blogabet.com/pick/16789499/atlanta-united-washington-dc-united",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon7);
            var pick71 = new Pick
            {
                Id = 7,
                KickOff = DateTime.Now,
                Odds = 2.01,
                Event = "Atlanta United - Washington DC United",
                Selection = "Atlanta United - Washington DC United",
                SportType = "Football / Livebet",
                Coupon = coupon7
            };
            context.Picks.AddOrUpdate(pick71);

            var coupon8 = new Coupon
            {
                Id = 8,
                Author = "LabatinPicks",
                AddedTime = DateTime.ParseExact("30.04.2017 22:47:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 51,
                AuthorsYield = 0.09,
                Odds = 1.871,
                Description = "",
                CouponUrl = "https://labatinpicks.blogabet.com/pick/16789634/combo-pick",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon8);
            var pick81 = new Pick
            {
                Id = 8,
                KickOff = DateTime.Now,
                Odds = 1.3,
                Event = "Bayern Munich vs Giessen 46ers",
                Selection = "Bayern Munich vs Giessen 46ers",
                SportType = "",
                Coupon = coupon8
            };
            context.Picks.AddOrUpdate(pick81);

            var pick82 = new Pick
            {
                Id = 9,
                KickOff = DateTime.Now,
                Odds = 1.22,
                Event = "Magura Cisnadie Women vs HC Dunarea Braila Women",
                Selection = "Magura Cisnadie Women vs HC Dunarea Braila Women",
                SportType = "",
                Coupon = coupon8
            };
            context.Picks.AddOrUpdate(pick82);

            var pick83 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 1.18,
                Event = "Astrahanochka Women vs Luch Moscow Women",
                Selection = "Astrahanochka Women vs Luch Moscow Women",
                SportType = "",
                Coupon = coupon8
            };
            context.Picks.AddOrUpdate(pick83);


            var coupon9 = new Coupon
            {
                Id = 9,
                Author = "Walter Joseph Kovacs",
                AddedTime = DateTime.ParseExact("30.04.2017 22:47:19", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 115,
                AuthorsYield = 0.1,
                Odds = 2.55,
                Description = "",
                CouponUrl = "https://wjk-rorschach.blogabet.com/pick/16789632/los-angeles-clippers-utah-jazz",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon9);
            var pick91 = new Pick
            {
                Id = 10,
                KickOff = DateTime.Now,
                Odds = 2.55,
                Event = "Los Angeles Clippers - Utah Jazz",
                Selection = "Los Angeles Clippers - Utah Jazz",
                SportType = "Basketball / Livebet",
                Coupon = coupon9
            };
            context.Picks.AddOrUpdate(pick91);


            var coupon10 = new Coupon
            {
                Id = 10,
                Author = "john_anthony",
                AddedTime = DateTime.ParseExact("30.04.2017 22:46:30", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 1411,
                AuthorsYield = 0.13,
                Odds = 3.5,
                Description = "",
                CouponUrl = "https://mastersanti.blogabet.com/pick/16785974/washington-nationals-new-york-mets",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon10);
            var pick101 = new Pick
            {
                Id = 11,
                KickOff = DateTime.Now,
                Odds = 3.5,
                Event = "Washington Nationals - New York Mets",
                Selection = "Washington Nationals - New York Mets",
                SportType = "Baseball / MLB",
                Coupon = coupon10
            };
            context.Picks.AddOrUpdate(pick101);


            var coupon11 = new Coupon
            {
                Id = 11,
                Author = "Betnike",
                AddedTime = DateTime.ParseExact("30.04.2017 22:46:19", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 968,
                AuthorsYield = 0.05,
                Odds = 2.066,
                Description = "",
                CouponUrl = "https://betnike69.blogabet.com/pick/16789626/combo-pick",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon11);
            var pick111 = new Pick
            {
                Id = 12,
                KickOff = DateTime.Now,
                Odds = 1.53,
                Event = "Club Nacional de Montevideo - Rampla Juniors",
                Selection = "Club Nacional de Montevideo - Rampla Juniors",
                SportType = "",
                Coupon = coupon11
            };
            context.Picks.AddOrUpdate(pick111);

            var pick112 = new Pick
            {
                Id = 13,
                KickOff = DateTime.Now,
                Odds = 1.35,
                Event = "Cerro Porteno - Libertad Asuncion",
                Selection = "Cerro Porteno - Libertad Asuncion",
                SportType = "",
                Coupon = coupon11
            };
            context.Picks.AddOrUpdate(pick112);


            var coupon12 = new Coupon
            {
                Id = 12,
                Author = "john_anthony",
                AddedTime = DateTime.ParseExact("30.04.2017 22:45:11", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 1411,
                AuthorsYield = 0.13,
                Odds = 3.25,
                Description = "",
                CouponUrl = "https://mastersanti.blogabet.com/pick/16789619/celikbilek-ilkel-podlipnik-castillo-vasilevski",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon12);
            var pick121 = new Pick
            {
                Id = 14,
                KickOff = DateTime.Now,
                Odds = 3.25,
                Event = "Celikbilek & Ilkel - Podlipnik-Castillo & Vasilevski",
                Selection = "Celikbilek & Ilkel - Podlipnik-Castillo & Vasilevski",
                SportType = "Tennis / Other",
                Coupon = coupon12
            };
            context.Picks.AddOrUpdate(pick121);


            var coupon13 = new Coupon
            {
                Id = 13,
                Author = "B-Rules",
                AddedTime = DateTime.ParseExact("30.04.2017 22:45:02", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 368,
                AuthorsYield = 0.27,
                Odds = 1.9,
                Description = "",
                CouponUrl = "https://tonik8.blogabet.com/pick/16789615/emelec-v-delfin-sc",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon13);
            var pick131 = new Pick
            {
                Id = 15,
                KickOff = DateTime.Now,
                Odds = 1.9,
                Event = "Emelec v Delfin SC",
                Selection = "Emelec v Delfin SC",
                SportType = "Football / Ecuador",
                Coupon = coupon13
            };
            context.Picks.AddOrUpdate(pick131);


            var coupon14 = new Coupon
            {
                Id = 14,
                Author = "lusanfer76",
                AddedTime = DateTime.ParseExact("30.04.2017 22:44:40", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 918,
                AuthorsYield = 0.07,
                Odds = 1.78,
                Description = "",
                CouponUrl = "https://lusanfer.blogabet.com/pick/16789613/real-madrid-atletico-madrid",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon14);
            var pick141 = new Pick
            {
                Id = 16,
                KickOff = DateTime.Now,
                Odds = 1.78,
                Event = "Real Madrid - Atletico Madrid",
                Selection = "Real Madrid - Atletico Madrid",
                SportType = "Football / Champions L",
                Coupon = coupon14
            };
            context.Picks.AddOrUpdate(pick141);


            var coupon15 = new Coupon
            {
                Id = 15,
                Author = "lusanfer76",
                AddedTime = DateTime.ParseExact("30.04.2017 22:43:55", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 918,
                AuthorsYield = 0.07,
                Odds = 1.833,
                Description = "",
                CouponUrl = "https://lusanfer.blogabet.com/pick/16789603/real-madrid-atletico-madrid",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false
            };
            context.Coupons.AddOrUpdate(coupon15);
            var pick151 = new Pick
            {
                Id = 17,
                KickOff = DateTime.Now,
                Odds = 1.833,
                Event = "Real Madrid - Atletico Madrid",
                Selection = "Real Madrid - Atletico Madrid",
                SportType = "Football / Champions L",
                Coupon = coupon15
            };
            context.Picks.AddOrUpdate(pick151);


            var coupon16 = new Coupon
            {
                Id = 16,
                Author = "Rambo",
                AddedTime = DateTime.ParseExact("06.06.2017 00:59:06", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 501,
                AuthorsYield = 0.07,
                Odds = 1.65,
                Description = "",
                CouponUrl = "https://rambinho.blogabet.com/pick/17198866/quilmes-atletico-club-patronato",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false,
                IsLive = true,
                AuthorsStake = 3
            };
            context.Coupons.AddOrUpdate(coupon16);
            var pick161 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 1.65,
                Event = "Quilmes Atletico Club - Patronato",
                Selection = "Quilmes Atletico Club - Patronato",
                SportType = "Football / Livebet",
                Coupon = coupon16
            };
            context.Picks.AddOrUpdate(pick161);


            var coupon17 = new Coupon
            {
                Id = 17,
                Author = "Rambo",
                AddedTime = DateTime.ParseExact("06.06.2017 00:58:56", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 501,
                AuthorsYield = 0.07,
                Odds = 2.15,
                Description = "",
                CouponUrl = "https://rambinho.blogabet.com/pick/17198865/quilmes-atletico-club-patronato",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false,
                IsLive = true,
                AuthorsStake = 3
            };
            context.Coupons.AddOrUpdate(coupon17);
            var pick171 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 2.15,
                Event = "Quilmes Atletico Club - Patronato",
                Selection = "Quilmes Atletico Club - Patronato",
                SportType = "Football / Livebet",
                Coupon = coupon17
            };
            context.Picks.AddOrUpdate(pick171);


            var coupon18 = new Coupon
            {
                Id = 18,
                Author = "kapetan",
                AddedTime = DateTime.ParseExact("06.06.2017 00:58:27", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 477,
                AuthorsYield = 0.21,
                Odds = 1.86,
                Description = "",
                CouponUrl = "https://kapetan.blogabet.com/pick/17198802/bucaneros-vs-marinos",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false,
                IsLive = true,
                AuthorsStake = 5
            };
            context.Coupons.AddOrUpdate(coupon18);
            var pick181 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 1.86,
                Event = "Bucaneros vs Marinos",
                Selection = "Bucaneros vs Marinos",
                SportType = "Basketball / Livebet",
                Coupon = coupon18
            };
            context.Picks.AddOrUpdate(pick181);


            var coupon19 = new Coupon
            {
                Id = 19,
                Author = "Bernhard",
                AddedTime = DateTime.ParseExact("06.06.2017 00:57:04", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 113,
                AuthorsYield = 0.08,
                Odds = 1.74,
                Description = "",
                CouponUrl = "https://bernhard97.blogabet.com/pick/17198846/nashville-predators-pittsburgh-penguins",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false,
                IsLive = false,
                AuthorsStake = 2
            };
            context.Coupons.AddOrUpdate(coupon19);
            var pick191 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 1.74,
                Event = "Nashville Predators - Pittsburgh Penguins",
                Selection = "Nashville Predators - Pittsburgh Penguins",
                SportType = "Ice Hockey / NHL",
                Coupon = coupon19
            };
            context.Picks.AddOrUpdate(pick191);


            var coupon20 = new Coupon
            {
                Id = 20,
                Author = "kike25041999",
                AddedTime = DateTime.ParseExact("06.06.2017 00:56:59", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 58,
                AuthorsYield = 0.06,
                Odds = 1.8,
                Description = "",
                CouponUrl = "https://quiquesanchezlaserna.blogabet.com/pick/17198842/bahrain-v-palestine",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false,
                IsLive = false,
                AuthorsStake = 10
            };
            context.Coupons.AddOrUpdate(coupon20);
            var pick201 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 1.8,
                Event = "Bahrain v Palestine",
                Selection = "Bahrain v Palestine",
                SportType = "Football / International",
                Coupon = coupon20
            };
            context.Picks.AddOrUpdate(pick201);


            var coupon21 = new Coupon
            {
                Id = 21,
                Author = "Bernhard",
                AddedTime = DateTime.ParseExact("06.06.2017 00:56:46", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 113,
                AuthorsYield = 0.08,
                Odds = 2.26,
                Description = "",
                CouponUrl = "https://bernhard97.blogabet.com/pick/17198839/los-angeles-dodgers-h-ryu-washington-nationals-g-gonzalez",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false,
                IsLive = false,
                AuthorsStake = 2
            };
            context.Coupons.AddOrUpdate(coupon21);
            var pick211 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 2.26,
                Event = "Los Angeles Dodgers (H. Ryu) - Washington Nationals (G. Gonzalez)",
                Selection = "Los Angeles Dodgers (H. Ryu) - Washington Nationals (G. Gonzalez)",
                SportType = "Baseball / MLB",
                Coupon = coupon21
            };
            context.Picks.AddOrUpdate(pick211);


            var coupon22 = new Coupon
            {
                Id = 22,
                Author = "Bernhard",
                AddedTime = DateTime.ParseExact("06.06.2017 00:56:36", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 113,
                AuthorsYield = 0.08,
                Odds = 1.751,
                Description = "",
                CouponUrl = "https://bernhard97.blogabet.com/pick/17198838/kansas-city-royals-i-kennedy-houston-astros-m-fiers",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false,
                IsLive = false,
                AuthorsStake = 2
            };
            context.Coupons.AddOrUpdate(coupon22);
            var pick221 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 1.751,
                Event = "Kansas City Royals (I. Kennedy) - Houston Astros (M. Fiers)",
                Selection = "Kansas City Royals (I. Kennedy) - Houston Astros (M. Fiers)",
                SportType = "Baseball / MLB",
                Coupon = coupon22
            };
            context.Picks.AddOrUpdate(pick221);


            var coupon23 = new Coupon
            {
                Id = 23,
                Author = "Bernhard",
                AddedTime = DateTime.ParseExact("06.06.2017 00:56:25", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 113,
                AuthorsYield = 0.08,
                Odds = 2.1,
                Description = "",
                CouponUrl = "https://bernhard97.blogabet.com/pick/17198837/chicago-cubs-e-butler-miami-marlins-d-straily",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false,
                IsLive = false,
                AuthorsStake = 2
            };
            context.Coupons.AddOrUpdate(coupon23);
            var pick231 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 2.1,
                Event = "Chicago Cubs (E. Butler) - Miami Marlins (D. Straily)",
                Selection = "Chicago Cubs (E. Butler) - Miami Marlins (D. Straily)",
                SportType = "Baseball / MLB",
                Coupon = coupon23
            };
            context.Picks.AddOrUpdate(pick231);


            var coupon24 = new Coupon
            {
                Id = 24,
                Author = "kike25041999",
                AddedTime = DateTime.ParseExact("06.06.2017 00:55:43", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 58,
                AuthorsYield = 0.06,
                Odds = 1.8,
                Description = "",
                CouponUrl = "https://quiquesanchezlaserna.blogabet.com/pick/17198834/india-v-nepal",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false,
                IsLive = false,
                AuthorsStake = 10
            };
            context.Coupons.AddOrUpdate(coupon24);
            var pick241 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 1.8,
                Event = "India v Nepal",
                Selection = "India v Nepal",
                SportType = "Football / International",
                Coupon = coupon24
            };
            context.Picks.AddOrUpdate(pick241);


            var coupon25 = new Coupon
            {
                Id = 25,
                Author = "kike25041999",
                AddedTime = DateTime.ParseExact("06.06.2017 00:55:15", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                AuthorsPicksCount = 58,
                AuthorsYield = 0.06,
                Odds = 1.25,
                Description = "",
                CouponUrl = "https://quiquesanchezlaserna.blogabet.com/pick/17198832/india-v-nepal",
                IsResolved = false,
                IsWon = false,
                IsPlayed = false,
                IsDismissed = false,
                IsLive = false,
                AuthorsStake = 10
            };
            context.Coupons.AddOrUpdate(coupon25);
            var pick251 = new Pick
            {
                KickOff = DateTime.Now,
                Odds = 1.25,
                Event = "India v Nepal",
                Selection = "India v Nepal",
                SportType = "Football / International",
                Coupon = coupon25
            };
            context.Picks.AddOrUpdate(pick251);


            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("polska12");
            context.Users.AddOrUpdate(u => u.UserName,
                new IdentityUser
                {
                    Email = "admin@wp.pl",
                    UserName = "admin@wp.pl",
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString()
                });

            #endregion

            context.SaveChanges();
        }
    }
}
