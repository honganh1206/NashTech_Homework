using CoreFramework.NUnitTestSetup;
using NUnit.Framework;
using RookiesTest.PageObj;
using TestProject1.DriverCore;

namespace RookiesTest
{
    [TestFixture]
    public class SimpleTests : NUnitTestSetup
    {

        public void UserCanInputUserName()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.InputUserName("text");
            WebDriverAction ss = new WebDriverAction(_driver);
            ss.ScreenShot();
        }
        [Test]
        public void UserCanGetTextElement()
        {

        }
    }
}