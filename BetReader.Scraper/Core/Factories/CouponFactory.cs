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


            return co;
        }

    }
}
