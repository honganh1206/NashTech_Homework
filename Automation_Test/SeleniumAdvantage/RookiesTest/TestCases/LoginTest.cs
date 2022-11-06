using RookiesTest.PageObj;
using RookiesTest.TestSetup;

namespace RookiesTest
{
    [TestFixture]
    public class LoginTest : ProjectNunitTestSetup
    {

        [Test]
        public void UserCanInputUserName()
        {
            LoginPage loginPage = new LoginPage(_driver);
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
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.InputUserName("text");
            //WebDriverAction ss = new WebDriverAction(_driver, _extentTestCase);
            //ss.TakeMultipleScreenShots();
        }
    }
}