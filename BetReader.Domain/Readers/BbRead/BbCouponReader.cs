using System.Collections.Generic;
using System.Linq;
using BetReader.Domain.Entities;
using BetReader.Domain.Readers.BbRead.BbParsers;
using BetReader.Domain.Readers.Interfaces;
using OpenQA.Selenium;

namespace BetReader.Domain.Readers.BbRead
{
    public class BbCouponReader : ICouponReader
    {
        private IWebDriver driver;

        public BbCouponReader(IWebDriver driver, string url)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl(url);
            //            Point windowHide = new Point(-1000, -1000);
            //            driver.Manage().Window.Position = windowHide;
        }

        public IEnumerable<Coupon> GetAll(double minAuthorYield, int minAuthorPicks)
        {
            List<Coupon> coupons = new List<Coupon>();
            var couponFactory = new CouponParser();

            IEnumerable<IWebElement> liElements = driver.FindElements(By.TagName("li"));
            List<IWebElement> couponNodes = liElements.Where(e => e.GetAttribute("class").Contains("feed-pick")).ToList();

            var expandCouponsCommand = "$('.combo-toggle').each(function(index) {" +
              "$(this).click()" +
              "});";

            ((IJavaScriptExecutor)driver).ExecuteScript(expandCouponsCommand);

            foreach (IWebElement node in couponNodes)
            {
                Coupon c = couponFactory.GetCoupon(node);
                if (c != null &&
                    c.Author.Yield >= minAuthorYield &&
                    c.Author.PicksCount >= minAuthorPicks)
                {
                    coupons.Add(c);
                }
            }
            if (coupons.Count == 0)
            {
                //make screenshot and download page
            }

            return coupons;
        }

        public void Dispose()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
