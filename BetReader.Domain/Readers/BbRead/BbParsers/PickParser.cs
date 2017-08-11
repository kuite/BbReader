using System;
using BetReader.Domain.Entities;
using OpenQA.Selenium;

namespace BetReader.Domain.Readers.BbRead.BbParsers
{
    public class PickParser
    {
        public Pick GetPick(IWebElement source)
        {
            var pick = new Pick();

            SetEventCombo(pick, source);
            SetSportTypeCombo(pick, source);
            SetSelectionCombo(pick, source);
            SetOddsCombo(pick, source);

            return pick;
        }

        public Pick GetPick(string[] sourceText)
        {
            var pick = new Pick();

            SetEventSingle(pick, sourceText);
            SetKickOffSingle(pick, sourceText);
            SetSportTypeSingle(pick, sourceText);
            SetSelectionSingle(pick, sourceText);
            SetSingleOdds(pick, sourceText);

            return pick;
        }

        private void SetEventCombo(Pick pick, IWebElement singlePick)
        {
            pick.Event = singlePick.FindElements(By.TagName("td"))[1].Text;
        }

        private void SetEventSingle(Pick pick, string[] postLines)
        {
            pick.Event = postLines[3].Replace("\r", "");
        }

        private void SetKickOffSingle(Pick pick, string[] postLines)
        {
            string kickOffLine = postLines[6].Replace("\r", "");
            int dateStart = kickOffLine.IndexOf("Kick off:") + 10;
            string KickOffStr = kickOffLine.Substring(dateStart);
            pick.KickOff = DateTime.ParseExact(KickOffStr, "dd MMM yyyy, HH:mm",
                System.Globalization.CultureInfo.InvariantCulture);
        }

        private void SetSportTypeSingle(Pick pick, string[] postLines)
        {
            string kickOffLine = postLines[6].Replace("\r", "");
            int sportEndIndex = kickOffLine.IndexOf("/", kickOffLine.IndexOf("/") + 1);
            pick.SportType = kickOffLine.Substring(0, sportEndIndex - 1);
        }

        private void SetSportTypeCombo(Pick pick, IWebElement singlePick)
        {
            pick.SportType = singlePick.FindElement(By.TagName("div")).GetAttribute("title data-orginal-title");
        }

        private void SetSelectionSingle(Pick pick, string[] postLines)
        {
            pick.Selection = postLines[4].Replace("\r", "");
        }

        private void SetSelectionCombo(Pick pick, IWebElement singlePick)
        {
            pick.Selection = singlePick.FindElements(By.TagName("td"))[2].Text;
        }

        private void SetOddsCombo(Pick pick, IWebElement singlePick)
        {
            var oddsString = singlePick.FindElements(By.TagName("td"))[3].Text.Replace(".", ",");
            pick.Odds = double.Parse(oddsString);
        }

        private void SetSingleOdds(Pick pick, string[] sourceText)
        {
            string oddsLine = sourceText[4].Replace("\r", "");
            int oddsStartIndex = oddsLine.IndexOf("@") + 1;
            string oddsAsString = oddsLine.Substring(oddsStartIndex).Replace(" ", "").Replace(".", ",");
            pick.Odds = double.Parse(oddsAsString);
        }

    }
}
