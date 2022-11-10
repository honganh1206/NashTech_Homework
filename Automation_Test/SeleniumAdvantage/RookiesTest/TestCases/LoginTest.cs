using RookiesTest.PageObj;
using RookiesTest.TestSetup;

namespace RookiesTest
{
    [TestFixture]
    public class LoginTest : RookieTest_ProjectNunitTestSetup
    {

        [Test]
        public void UserCanInputUserName()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.InputUserName("text");
        }
        [Test]
        // Testing report with another test case
        public void UserCanInputUserName2()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.InputUserName("text");
        }
    }
}