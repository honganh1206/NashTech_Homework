using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RookiesTest.PageObj
{
    public class HomePage : HeaderPage
    {
        private readonly IWebDriver? _driver;
        public HomePage(IWebDriver? driver): base(driver)
        {
            _driver = driver;
        }
        private readonly By videoTitles = By.XPath("//*[@id='video-title']");

        public IList<IWebElement>? GetVideoTitles()
        {
            return _driver?.FindElements(videoTitles);
        }

    }

}
