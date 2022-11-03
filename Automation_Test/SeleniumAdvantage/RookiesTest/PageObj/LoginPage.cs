using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using CoreFramework.DriverCore;

namespace RookiesTest.PageObj
{
    public class LoginPage : WebDriverAction
    {
        public LoginPage(IWebDriver? driver) : base(driver)
        {
        }

        private readonly string userNameLocator = "//input[@name = 'uid']";
        public void InputUserName(string Username)
        {
            SendKeys_(userNameLocator, Username);
        }
    }
}
