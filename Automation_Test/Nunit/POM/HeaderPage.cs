using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Nunit.POM
{
    public class HeaderPage
    {
        private readonly IWebDriver? _driver;
        private By searchBox = By.XPath("//*[contains(@title,'Tìm kiếm')]");
        //private By searchBtn;

        public HeaderPage(IWebDriver? driver)
        {
            _driver = driver;
        }

        public IWebElement? GetSearchBox()
        {
            return _driver?.FindElement(searchBox);
        }
        //public IWebElement? GetSearchButton()
        //{
        //    return _driver?.FindElement(searchBtn);
        //}

        // Input keywords
        public HeaderPage Search(string keyword)
        {
            GetSearchBox()?.Clear();
            GetSearchBox()?.SendKeys(keyword);
            return this;
        }
        public Pages Enter(By searchBox)
        {
            GetSearchBox()?.SendKeys(Keys.Enter);
            return new Pages(_driver);
        }

    }
}
