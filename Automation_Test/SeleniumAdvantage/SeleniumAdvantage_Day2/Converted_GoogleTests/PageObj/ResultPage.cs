using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace SeleniumAdvantage_Day2.PageObj
{
    public class ResultPage : WebDriverAction
    {
        public ResultPage(IWebDriver? driver): base(driver)
        {
        }
        private string firstResult = "//*[contains(@h3,\"\") " +
            "and text()= 'Reddit - Dive into anything']";

        public void GetFirstResult()
        {
            Click((FindElementByXpath(firstResult)));
        }
        public string GetTitleBeforeDash()
        {
            return GetTitle().Substring(0, GetTitle().IndexOf("-")).Trim();
        }

    }

}
