using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BetReader.Api.Controllers;
using BetReader.Api.Models.Database;
using BetReader.Api.Models.Repositores;
using BetReader.Api.Models.Services;
using BetReader.Constans;
using BetReader.Model.Entities;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using RestSharp;

namespace BetReader.Service.Core.DataAccess
{
    public class ApiWrapper : IDataProvider
    {
        private string authToken;

        public ApiWrapper()
        {
            RefreshToken();
        }

        public List<Coupon> GetCouponsInPlay()
        {
            var client = new RestClient(GlobalConstants.LocalApiUrl + "/api/Bet/GetCouponsInPlay");
            var getRequest = new RestRequest(Method.GET);
            getRequest.AddHeader("content-type", "application/json");
            getRequest.AddHeader("authorization", authToken);
            IRestResponse response = client.Execute(getRequest);
            if (response.StatusDescription == "InvalidToken")
            {
                RefreshToken();
                return GetCouponsInPlay();
            }
            List<Coupon> couponsInPlay = JsonConvert.DeserializeObject<List<Coupon>>(response.Content);
            return couponsInPlay;
        }

        public void UpdateCoupons(List<Coupon> coupons)
        {
            var client = new RestClient(GlobalConstants.LocalApiUrl + "/api/Bet/UpdateCoupons");
            var postRequest = new RestRequest(Method.POST);
            postRequest.AddHeader("content-type", "application/json");
            postRequest.AddParameter("data", coupons);
            postRequest.AddHeader("authorization", authToken);
            IRestResponse response = client.Execute(postRequest);
            if (response.StatusDescription == "InvalidToken")
            {
                RefreshToken();
                UpdateCoupons(coupons);
            }
        }

        public void AddCouponsToPlay(List<Coupon> coupons)
        {
            var client = new RestClient(GlobalConstants.LocalApiUrl + "/api/Bet/AddNewCoupons");
            var postRequest = new RestRequest(Method.POST);
            var json = JsonConvert.SerializeObject(coupons);

            postRequest.AddHeader("content-type", "application/json");
            postRequest.AddHeader("authorization", authToken);
            postRequest.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(postRequest);
            if (response.StatusDescription == "InvalidToken")
            {
                RefreshToken();
                AddCouponsToPlay(coupons);
            }
        }

        public void CreateSeedToConsole(Coupon coupon)
        {
            var id = 16;
            var couponName = "coupon" + id;
            var addedTime = string.Format(
                "DateTime.ParseExact('{0}', 'dd.MM.yyyy HH:mm:ss', CultureInfo.InvariantCulture)", coupon.AddedTime);
            var odds = coupon.Odds.ToString().Replace(",", ".");
            var yield = coupon.AuthorsYield.ToString().Replace(",", ".");

            var couponText = string.Format(
            @"var {0} = new Coupon
            {{
                Id = {1},
                Author = '{2}',
                AddedTime = {3},
                AuthorsPicksCount = {4},
                AuthorsYield = {5},
                Odds = {6},
                Description = '{7}',
                CouponUrl = '{8}',
                IsResolved = {9},
                IsWon = {10},
                IsPlayed = {11},
                IsDismissed = {12},
                IsLive = {14},
                AuthorsStake = {15}
            }};
            context.Coupons.AddOrUpdate({13});", 
            couponName, id, coupon.Author, addedTime, coupon.AuthorsPicksCount, 
            yield, odds, coupon.Description, coupon.CouponUrl,
            "false", "false", "false", "false", couponName, coupon.IsLive.ToString().ToLower(), coupon.AuthorsStake);
            couponText += Environment.NewLine;

            var pickId = 1;
            foreach (Pick pick in coupon.Picks)
            {
                var pickOdds = pick.Odds.ToString().Replace(",", ".");
                var pickName = "pick" + id + pickId;

                var pickText = string.Format(
                @"var {0} = new Pick
                {{
                    KickOff = DateTime.Now,
                    Odds = {1},
                    Event = '{2}',
                    Selection = '{3}',
                    SportType = '{4}',
                    Coupon = {5}
                }};
                context.Picks.AddOrUpdate({6});
                ", pickName, pickOdds, pick.Event, pick.Event, pick.SportType, couponName, pickName);

                pickText += Environment.NewLine;
                couponText += pickText;
                pickId++;
            }

            Console.WriteLine(couponText.Replace("'", "\""));
            id++;
        }

        private void RefreshToken()
        {
            var body = string.Format("{{\r\n    Email: \"{0}\",\r\n    Password: \"{1}\"\r\n}}", "admin@wp.pl", "polska12");
            var client = new RestClient(GlobalConstants.LocalApiUrl + "/api/Token/GetToken");
            var postRequest = new RestRequest(Method.POST);
            postRequest.AddHeader("content-type", "application/json");
            postRequest.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(postRequest);
            authToken = "Bearer " + response.Content.Remove(response.Content.Length - 1).Remove(0, 1);
        }
    }
}
