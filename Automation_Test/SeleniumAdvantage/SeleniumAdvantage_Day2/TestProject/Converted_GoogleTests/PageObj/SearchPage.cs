using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace SeleniumAdvantage_Day2.PageObj
{
    public class SearchPage : WebDriverAction
    {
        public SearchPage(IWebDriver? driver) : base(driver)
        {
        }
        //
        private string searchBarLocator = "//*[contains(@title,'Tìm kiếm')]";
        public void InputSearch(string Search)
        {
            SendKeys_(searchBarLocator, Search);
            PressEnter(searchBarLocator);
        }
    }

}
