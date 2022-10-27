using OpenQA.Selenium;

namespace Nunit.POM
{
    public class Pages : HeaderPage
    {
        private readonly IWebDriver? _driver;

        public Pages(IWebDriver? driver) : base(driver)
        {
            _driver = driver;
        }

        private By firstResult = By.XPath(
            "//*[contains(@h3,\"\") and text()= 'Reddit - Dive into anything']");
        public IWebElement? getFirstResult()
        {
            return _driver?.FindElement(firstResult);
        }

        private By signUpBtn = By.XPath(
            "//*[contains(@href," +
            "'https://www.reddit.com/register/?dest=https%3A%2F%2Fwww.reddit.com%2F')]");
        
        public IWebElement? getSignUpBtn()
        {
            return _driver?.FindElement(signUpBtn);
        }
    }
}