using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleAndNunit.Pages
{
    internal class HeaderPage
    {
        private readonly IWebDriver? _driver;
        private readonly By searchBox = By.XPath("//*");
        private readonly By searchButton = By.XPath("//*");
        
        public HeaderPage(IWebDriver? driver)
        {
            _driver = driver;
        }

        public IWebElement? GetSearchBox()
        {
            return _driver?.FindElement(searchBox);
        }

        public IWebElement? GetSearchButton()
        {
            return _driver?.FindElement(searchButton);
        }

        // Input keywords
        public HeaderPage Search(string keyword)
        {
            GetSearchBox()?.Clear();
            GetSearchButton()?.SendKeys(keyword);
            return this;
        }
        public VideoPage ClickSearchButton()
        {
            GetSearchButton()?.Click();
            return new VideoPage(_driver);
        }

    }
}
