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
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.InputUserName("text");
            WebDriverAction ss = new WebDriverAction(_driver);
            ss.ScreenShot();
        }
        /*[Test]
        public void UserCanGetTextElement()
        {

        }*/
    }
}