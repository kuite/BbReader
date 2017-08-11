using System;
using System.Linq;
using BetReader.Domain.Entities;
using BetReader.Domain.Entities.Enums;
using OpenQA.Selenium;

namespace BetReader.Domain.Readers.BbRead.BbParsers
{
    public class CouponParser
    {
        private readonly PickParser pickParser;

        private readonly AuthorParser authorParser;

        public CouponParser()
        {
            authorParser = new AuthorParser();
            pickParser = new PickParser();
        }

        public Coupon GetCoupon(IWebElement source)
        {
            var co = new Coupon();
            string[] sourceText = source.Text.Split('\n');

            if (IsCouponVisible(sourceText))
            {
                Author ath = authorParser.GetAuthor(source);
                ParsePicks(co, source, sourceText);

                co.Author = ath;
                co.Odds = GetOdds(sourceText);
                co.CreatedAtSource = GetCreatedTime(source);
                co.Description = GetDescription(source);
                co.CouponUrl = GetUrl(source);
                co.SuggestedStake = GetAuthorsStake(sourceText);
                co.IsLive = IsLive(sourceText);
            }
            else
            {
                return null;
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
                    var pick = pickParser.GetPick(p);
                    pick.KickOff = DateTime.Now + TimeSpan.FromHours(12);
                    coupon.Picks.Add(pick);
                }
            }
            else
            {
                var pick = pickParser.GetPick(sourceText);
                pick.Event = title;
                coupon.Picks.Add(pick);
            }
        }

        private bool IsCouponVisible(string[] sourceText)
        {
            return !sourceText[4].Contains("Click here") && sourceText[1].Contains("published a new pick");
        }

        private bool IsLive(string[] postLines)
        {
            return postLines[5].Contains(" LIVE ");
        }

        private int GetAuthorsStake(string[] postLines)
        {
            string authorsStakeLine = postLines[5];
            int endIndex = authorsStakeLine.IndexOf("/10");
            string stakeString = authorsStakeLine.Substring(0, endIndex);
            return int.Parse(stakeString);
        }

        private string GetUrl(IWebElement source)
        {
            IWebElement hrefNode = Helpers.GetHrefNode(source);
            return hrefNode.GetAttribute("href");
//            try
//            {
//                IWebElement hrefNode = Helpers.GetHrefNode(source);
//                return hrefNode.GetAttribute("href");
//            }
//            catch (NoSuchElementException ex)
//            {
//                //coupon.
//            }
            
        }

        private string GetDescription(IWebElement source)
        {
            IWebElement descContainer = source.FindElement(By.CssSelector(".feed-analysis div"));
            return descContainer.Text;
        }

        private double GetOdds(string[] postLines)
        {
            string oddsLine = postLines[4].Replace("\r", "");
            int oddsStartIndex = oddsLine.IndexOf("@") + 1;
            string oddsAsString = oddsLine.Substring(oddsStartIndex).Replace(" ", "").Replace(".", ",");
            return double.Parse(oddsAsString);
        }

        private DateTime GetCreatedTime(IWebElement source)
        {
            string addTimeString = source.GetAttribute("data-time");
            double addTime = double.Parse(addTimeString);
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(addTime).ToLocalTime();
        }
    }
}
