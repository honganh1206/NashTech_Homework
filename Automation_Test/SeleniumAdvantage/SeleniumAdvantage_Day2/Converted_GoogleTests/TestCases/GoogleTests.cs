using CoreFramework.DriverCore;
using OpenQA.Selenium;
using Assert = NUnit.Framework.Assert;
using SeleniumAdvantage_Day2.PageObj;
using SeleniumAdvantage_Day2.TestSetup;
using SeleniumAdvantage_Day2.Converted_Day2_Selenium_Practice2_Scenario1.PageObj;

namespace SeleniumAdvantage_Day2.Converted_GoogleTests.TestCases
{
    public class GoogleTests : Scenario1_Test_ProjectNunitTestSetup
    {

        [Test]
        public void UserCanInputSearch()
        {
            SearchPage searchPage = new SearchPage(_driver);
            searchPage.InputSearch("reddit");
            ResultPage resultPage = new ResultPage(_driver);
            resultPage.CompareTitle("reddit");
            resultPage.GetFirstResult();
            resultPage.CompareText("Sign Up");
        }
    }
}
