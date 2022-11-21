using OpenQA.Selenium;
using RookiesTest.PageObj;
using RookiesTest.TestSetup;

namespace RookiesTest
{
    [TestFixture]
    public class LoginTest : NUnitWebTestSetup
    {
        [Test]
        public void UserCanInputUserName()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.doLogin("mngr454797", "EqajuhA");
        }
    }
}