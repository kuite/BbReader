using System.Collections.Generic;
using BetReader.Model.Entities;
using HtmlAgilityPack;

namespace BetReader.Scraper.Core
{
    public class FeedResolver
    {
        private readonly HtmlWeb web;

        public FeedResolver(HtmlWeb web)
        {
            this.web = web;
        }

        public IEnumerable<Coupon> ResolveCoupons(IEnumerable<Coupon> coupons)
        {
            foreach (var coupon in coupons)
            {
                string url = coupon.CouponUrl;
                HtmlDocument doc = web.Load(url);
                HtmlNode resultNode = doc.DocumentNode.SelectSingleNode("//div[@class='labels']//span[@title]");
                if (resultNode != null)
                {
                    var result = resultNode.Attributes["title"].Value;
                    coupon.IsResolved = true;
                    if (result.Contains("LOST"))
                    {
                        coupon.IsWon = false;
                    }
                    else if (result.Contains("WIN"))
                    {
                        coupon.IsWon = true;
                    }
                }
                yield return coupon;
            }
        }
    }
}
