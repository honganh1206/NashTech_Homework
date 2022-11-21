using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace RookiesTest.PageObj
{
    public class MenuLeft : WebDriverAction
    {
        public MenuLeft(IWebDriver driver): base(driver)
        {

        }

        private string btnNewCustomer = "//marquee";

        public void GoToCreateCustomerPage()
        {
            Click(btnNewCustomer);

        }
    }
}
