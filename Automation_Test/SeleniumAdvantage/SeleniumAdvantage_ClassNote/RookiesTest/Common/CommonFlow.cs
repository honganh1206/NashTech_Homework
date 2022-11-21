using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RookiesTest.PageObj;
using RookiesTest.TestSetup;
using OpenQA.Selenium;

namespace RookiesTest.Common
{
    // Login for every test case
    public class CommonFlow : NUnitWebTestSetup
    {
        public static void LoginFLow(IWebDriver _driver)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.doLogin("mngr454797", "EqajuhA");
        }
    }
}
