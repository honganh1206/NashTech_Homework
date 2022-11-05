using CoreFramework.DriverCore;
using CoreFramework.NUnitTestSetup;
using OpenQA.Selenium;
using RookiesTest.PageObj;
using RookiesTest.TestSetup;

namespace RookiesTest
{
    public class SimpleTests : ProjectNunitTestSetup
    {

        [Test]
        public void UserCanInputUserName()
        {
            LoginPage loginPage = new LoginPage(_driver, _extentTestCase);
            loginPage.InputUserName("text");
            //WebDriverAction ss = new WebDriverAction(_driver, _extentTestCase);
            //ss.TakeMultipleScreenShots();
        }
        /*[Test]
        public void UserCanGetTextElement()
        {

        }*/
        [Test]
        public void UserCanInputUserName2()
        {
            LoginPage loginPage = new LoginPage(_driver, _extentTestCase);
            loginPage.InputUserName("text");
            //WebDriverAction ss = new WebDriverAction(_driver, _extentTestCase);
            //ss.TakeMultipleScreenShots();
        }
    }
}