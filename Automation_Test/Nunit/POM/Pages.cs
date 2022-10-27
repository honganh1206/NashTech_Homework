using OpenQA.Selenium;

namespace Nunit.POM
{
    public class Pages
    {
        private readonly IWebDriver? _driver;
        private readonly By firstResult;
        private readonly By signUpBtn; 

        public Pages(IWebDriver? driver)
        {
            _driver = driver;
        }
        public string? linkToFirstResult()
        {
            return _driver?.FindElement(firstResult).GetAttribute("href");
        }
        //public string? getSignUpBtn()
        //{
        //    IWebElement getSignUpBtn = _driver?.FindElement(signUpBtn);
        //    return getSignUpBtn
        //}
    }
}