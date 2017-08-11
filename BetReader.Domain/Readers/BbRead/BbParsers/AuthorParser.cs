using BetReader.Domain.Entities;
using BetReader.Domain.Entities.Enums;
using OpenQA.Selenium;

namespace BetReader.Domain.Readers.BbRead.BbParsers
{
    public class AuthorParser
    {
        public Author GetAuthor(IWebElement source)
        {
            string[] sourceText = source.Text.Split('\n');
            var athr = new Author();

            athr.Yield = GetYield(sourceText);
            athr.PicksCount = GetPicksCount(sourceText);
            athr.Name = GetName(sourceText);
            athr.HomeSite = Source.Blogabet;

            return athr;
        }

        private double GetYield(string[] postLines)
        {
            string authorsResults = postLines[0];
            string authorsYieldString = authorsResults.Substring(0, authorsResults.IndexOf("%"));
            double authorsYield = double.Parse(authorsYieldString) / 100;
            return authorsYield;
        }

        private int GetPicksCount(string[] postLines)
        {
            string authorsResults = postLines[0];
            int startPostCount = authorsResults.IndexOf("(") + 1;
            int endPostCount = authorsResults.IndexOf(")");
            string authorsCountStr = authorsResults.Substring(startPostCount, endPostCount - startPostCount);
            int authorsPicksCount = int.Parse(authorsCountStr);
            return authorsPicksCount;
        }

        private string GetName(string[] postLines)
        {
            string authorsLine = postLines[1];
            int nickEndIndex = authorsLine.IndexOf("published") - 1;
            if (nickEndIndex > 0)
            {
                return authorsLine.Substring(0, nickEndIndex);
            }
            else
            {
                return authorsLine;
            }
        }
    }
}
