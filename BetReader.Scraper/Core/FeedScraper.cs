using System;
using System.Collections.Generic;
using System.Linq;
using BetReader.Constans;
using BetReader.Model.Entities;
using BetReader.Scraper.Core.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace BetReader.Scraper.Core
{
    public class FeedScraper : IDisposable
    {
        private readonly IWebDriver driver;

        public FeedScraper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IEnumerable<Coupon> GetValuableCoupons(string sourceUrl)
        {
            driver.Navigate().GoToUrl(sourceUrl);

            List<Coupon> coupons = new List<Coupon>();
            var couponFactory = new CouponFactory();

            IEnumerable<IWebElement> liElements = driver.FindElements(By.TagName("li"));
            List<IWebElement> couponNodes = liElements.Where(e => e.GetAttribute("class").Contains("feed-pick")).ToList();

            var command = "$('.combo-toggle').each(function(index) {" +
              "$(this).click()" +
              "});";

            ((IJavaScriptExecutor)driver).ExecuteScript(command);


            foreach (IWebElement node in couponNodes)
            {
                coupons.Add(couponFactory.GetCoupon(node));
            }

            foreach (Coupon c in coupons)
            {
                if (c.AuthorsPicksCount >= GlobalConstants.MinimalPicksCount &&
                    c.AuthorsYield >= GlobalConstants.MinimalYield)
                {
                    yield return c;
                }
            }
        }

        public void Dispose()
        {
            driver.Close();
            driver.Dispose();
            Environment.Exit(0);
        }
    }
}
