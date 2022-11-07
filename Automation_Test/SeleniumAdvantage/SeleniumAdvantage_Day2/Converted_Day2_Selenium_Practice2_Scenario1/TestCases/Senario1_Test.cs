using CoreFramework.DriverCore;
using OpenQA.Selenium;
using Assert = NUnit.Framework.Assert;
using SeleniumAdvantage_Day2.PageObj;
using SeleniumAdvantage_Day2.TestSetup;
using SeleniumAdvantage_Day2.Converted_Day2_Selenium_Practice2_Scenario1.PageObj;

namespace SeleniumAdvantage_Day2.Converted_GoogleTests.TestCases
{
    public class Senario1_Test : Scenario1_Test_ProjectNunitTestSetup
    {

        [Test]
        public void VerifyTitle ()
        {
            Page testPage = new Page(_driver);
            testPage.ClickBtn();
            testPage.VerifyText("CUSTOMER SERVICE - CONTACT US");
            testPage.MoveBackward();
            testPage.VerifyPageTitle("My Store");
            testPage.MoveForward();
        }
    }
}
