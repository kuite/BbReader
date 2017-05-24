using System;
using OpenQA.Selenium;

namespace BetReader.Scraper
{
    public static class Helpers
    {
        public static IWebElement GetHrefNode(IWebElement source)
        {
            return source
                .FindElement(By.ClassName("feed-pick-title"))
                .FindElement(By.TagName("a"));
        }

        public static void ScrollTo(IWebDriver driver, int xPosition = 0, int yPosition = 0)
        {
            var js = string.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
            ((IJavaScriptExecutor)driver).ExecuteScript(js);
        }

        public static void ScrollToView(this IWebElement element, IWebDriver driver)
        {
            if (element.Location.Y > 200)
            {
                ScrollTo(driver, 0, element.Location.Y - 100);
            }

        }
    }
}