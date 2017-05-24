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

        public IEnumerable<Coupon> GetValuableCoupons()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            driver.Close();
            driver.Dispose();
            Console.WriteLine("------------------- driver disposed");
        }
    }
}
