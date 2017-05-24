using System;
using System.Linq;
using BetReader.Model.Entities;
using OpenQA.Selenium;

namespace BetReader.Scraper.Core.Factories
{
    public class CouponFactory
    {
        private readonly PickFactory pickFactory;

        public CouponFactory()
        {
            pickFactory = new PickFactory();
        }

        public Coupon GetCoupon(IWebElement source)
        {
            var co = new Coupon();
            string[] sourceText = source.Text.Split('\n');

            SetAuthorsYield(co, sourceText);
            SetAuthorsPicksCount(co, sourceText);
            SetAuthor(co, sourceText);
            SetCouponUrl(co, source);
            SetAddedTime(co, source);

            if (IsCouponValid(sourceText))
            {
                SetDescription(co, source);
                SetOdds(co, sourceText);
                ParsePicks(co, source, sourceText);
                SetAuthorsStake(co, sourceText);
                IsLive(co, sourceText);
            }
            else
            {
                co.Description = "not specified";
                co.Odds = 0;
                co.AuthorsStake = 0;
                co.IsLive = false;
            }

            return co;
        }

        private void ParsePicks(Coupon coupon, IWebElement source, string[] sourceText)
        {
            var title = Helpers.GetHrefNode(source).Text;

            if (title == "Combo pick")
            {
                var picks = source.FindElements(By.CssSelector("table.combo-table > tbody > tr")).ToList();
                picks.RemoveAt(0);
                foreach (var p in picks)
                {
                    var pick = pickFactory.GetPick(p);
                    pick.KickOff = DateTime.Now + TimeSpan.FromHours(12);
                    coupon.Picks.Add(pick);
                }
            }
            else
            {
                var pick = pickFactory.GetPick(sourceText);
                pick.Event = title;
                coupon.Picks.Add(pick);
            }
        }

        private bool IsCouponValid(string[] sourceText)
        {
            return !sourceText[4].Contains("Click here");
        }

        private void SetAuthorsYield(Coupon coupon, string[] postLines)
        {
            string authorsResults = postLines[0];
            string authorsYieldString = authorsResults.Substring(0, authorsResults.IndexOf("%"));
            double authorsYield = double.Parse(authorsYieldString) / 100;
            coupon.AuthorsYield = authorsYield;
        }

        private void SetAuthorsPicksCount(Coupon coupon, string[] postLines)
        {
            string authorsResults = postLines[0];
            int startPostCount = authorsResults.IndexOf("(") + 1;
            int endPostCount = authorsResults.IndexOf(")");
            string authorsCountStr = authorsResults.Substring(startPostCount, endPostCount - startPostCount);
            int authorsPicksCount = int.Parse(authorsCountStr);
            coupon.AuthorsPicksCount = authorsPicksCount;
        }

        private void SetAuthorsStake(Coupon coupon, string[] postLines)
        {
            string authorsStakeLine = postLines[5];
            int endIndex = authorsStakeLine.IndexOf("/10");
            string stakeString = authorsStakeLine.Substring(0, endIndex);
            coupon.AuthorsStake = int.Parse(stakeString);
        }

        private void IsLive(Coupon coupon, string[] postLines)
        {
            coupon.IsLive = postLines[5].Contains(" LIVE ");
        }

        private void SetAuthor(Coupon coupon, string[] postLines)
        {
            string authorsLine = postLines[1];
            int nickEndIndex = authorsLine.IndexOf("published") - 1;
            coupon.Author = authorsLine.Substring(0, nickEndIndex);
        }

        private void SetCouponUrl(Coupon coupon, IWebElement source)
        {
            IWebElement hrefNode = Helpers.GetHrefNode(source);
            coupon.CouponUrl = hrefNode.GetAttribute("href");
        }

        private void SetDescription(Coupon coupon, IWebElement source)
        {
            IWebElement descContainer = source.FindElement(By.CssSelector(".feed-analysis div"));
            coupon.Description = descContainer.Text;
        }

        private void SetOdds(Coupon coupon, string[] postLines)
        {
            string oddsLine = postLines[4].Replace("\r", "");
            int oddsStartIndex = oddsLine.IndexOf("@") + 1;
            string oddsAsString = oddsLine.Substring(oddsStartIndex).Replace(" ", "").Replace(".", ",");
            coupon.Odds = double.Parse(oddsAsString);
        }

        private void SetAddedTime(Coupon coupon, IWebElement source)
        {
            string addTimeString = source.GetAttribute("data-time");
            double addTime = double.Parse(addTimeString);
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            coupon.AddedTime = dtDateTime.AddSeconds(addTime).ToLocalTime();
        }
    }
}
