using OpenQA.Selenium;
using CoreFramework.DriverCore;

namespace RookiesTest.PageObj
{
    public class LoginPage : WebDriverAction
    {
        public LoginPage(IWebDriver? driver) : base(driver)
        {
        }

        private string tfUserName = "//input[@name = 'uid']";
        private string tfPassword = "//input[@name = 'password']";
        private string btnLogin = "//button[@name = 'btnLogin']";


        public void doLogin(string Username, string Password)
        {
            SendKeys_(tfUserName, Username);
            SendKeys_(tfPassword, Password);
            Click(btnLogin);
        }
    }
}
