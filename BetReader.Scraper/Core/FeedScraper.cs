using System;
using System.Collections.Generic;
using System.Linq;
using BetReader.Constans;
using BetReader.Model.Entities;
using BetReader.Scraper.Core.Factories;
using OpenQA.Selenium;

namespace BetReader.Scraper.Core
{
    public class FeedScraper : IDisposable
    {
        private readonly IWebDriver driver;

        public FeedScraper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IEnumerable<Coupon> GetValuableCoupons(string sourcePath)
        {
            List<Coupon> coupons = new List<Coupon>();
            var couponFactory = new CouponFactory();

            if (driver.Url.Length < 10)
            {
                driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 7);
                try
                {
                    driver.Navigate().GoToUrl(sourcePath);
                }
                catch (WebDriverTimeoutException ex)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("return window.stop();");
                    Console.WriteLine("Stop loading page forced");
                }
            }

            IEnumerable<IWebElement> liElements = driver.FindElements(By.TagName("li"));
            List<IWebElement> couponNodes = liElements.Where(e => e.GetAttribute("class").Contains("feed-pick")).ToList();

            foreach (IWebElement node in couponNodes)
            {
                //todo: filter here if post is worth to check further

                if (node.Text.Contains("Combo pick"))
                {
                    var toggle = node.FindElement(By.ClassName("combo-toggle"));
                    if (toggle != null && toggle.Text.Contains("Show"))
                    {
                        toggle.ScrollToView(driver);
                        toggle.Click();
                    }
                }

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
        }
    }
}
