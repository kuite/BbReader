using System.Collections.Generic;
using BetReader.Domain.Entities;
using HtmlAgilityPack;

namespace BetReader.Domain.Resolvers
{
    public class BbCouponsResolver : ICouponResolver
    {
        private readonly HtmlWeb web;

        public BbCouponsResolver(HtmlWeb web)
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
                    if (result.Contains("LOST"))
                    {
                        coupon.Won = false;
                    }
                    else if (result.Contains("WIN"))
                    {
                        coupon.Won = true;
                    }
                }
                yield return coupon;
            }
        }
    }
}
