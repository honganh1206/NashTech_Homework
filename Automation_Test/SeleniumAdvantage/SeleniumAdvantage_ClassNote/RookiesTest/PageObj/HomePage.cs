using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace RookiesTest.PageObj
{
    public class HomePage : WebDriverAction
    {
        public HomePage(IWebDriver driver) : base(driver) 
        { 
        }

        private string HomePageWelcomeMessage = "//marquee";

        public bool IsWelcomeMessageDisplayed()
        {
            if (IsElementDisplay(HomePageWelcomeMessage) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
