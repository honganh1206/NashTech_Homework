using OpenQA.Selenium;

namespace Nunit.POM
{
    public class Pages : HeaderPage
    {
        private readonly IWebDriver? _driver;

        // for req 4
        //private readonly By firstResult;
        //private readonly ; 

        public Pages(IWebDriver? driver) : base(driver)
        {
            _driver = driver;
        }
        public IWebElement? getElem(By elem)
        {
            return _driver?.FindElement(elem);
        }
    }
}