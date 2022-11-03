using CoreFramework.DriverCore;
using OpenQA.Selenium;
using SeleniumAdvantage_Day2.PageObj;
using SeleniumAdvantage_Day2.TestSetup;

namespace SeleniumAdvantage_Day2.Converted_GoogleTests.TestCases
{
    public class GoogleTests : ProjectNunitTestSetup
    {
        [Test]
        public void UserCanInputSearch()
        {
            SearchPage searchPage = new SearchPage(_driver);
            searchPage.InputSearch("reddit");
            WebDriverAction ss = new WebDriverAction(_driver);
            ss.TakeMultipleScreenShots();


        }
    }
}
