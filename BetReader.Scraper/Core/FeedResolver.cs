using System;
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
            throw new NotImplementedException();
        }
    }
}
