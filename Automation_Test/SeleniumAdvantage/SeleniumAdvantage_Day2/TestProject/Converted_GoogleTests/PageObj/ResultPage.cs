using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace SeleniumAdvantage_Day2.Converted_Day2_Selenium_Practice2_Scenario1.PageObj
{
    public class ResultPage : WebDriverAction
    {
        public ResultPage(IWebDriver? driver) : base(driver)
        {
        }
        private string firstResultLocator = "//*[contains(@h3,\"\") " +
            "and text()= 'Reddit - Dive into anything']";

        public void GetFirstResult()
        {
            Click(firstResultLocator);
        }
        public void CompareTitle(string searchInput)
        {
            string stringBeforeDash = GetTitle().
                Substring(0,GetTitle().IndexOf("-")).Trim();
            Assert_(stringBeforeDash, searchInput);
        }
        private string signUpBtnLocator = "//*[contains(@href," +
    "'https://www.reddit.com/register/?dest=https%3A%2F%2Fwww.reddit.com%2F')]";
        public void CompareText(string expectedTextFromElem)
        {
            Assert_(GetTextFromElem(signUpBtnLocator), expectedTextFromElem);
        }

    }

}
