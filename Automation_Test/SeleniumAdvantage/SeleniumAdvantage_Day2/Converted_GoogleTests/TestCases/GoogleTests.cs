using CoreFramework.DriverCore;
using OpenQA.Selenium;
using Assert = NUnit.Framework.Assert;
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


            // Forgot to click enter to search
            //ResultPage resultPage = new ResultPage(_driver);
            //resultPage.GetFirstResult();
            //Assert.That(resultPage.GetTitleBeforeDash(), Is.EqualTo("reddit"));
        }
    }
}
