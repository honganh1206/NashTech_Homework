using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;







namespace SeleDay2
{
    [TestClass]
    public class TestingScenario
    {
        // shared vars
        protected WebDriverWait _wait;
        protected IWebDriver _driver;

        [SetUp]
        // prepare chromedriver
        public void SetUp()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Scenario1()
        {
            //
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Console.WriteLine("The website is opened successfully");

            // Click to “Contact Us” link on top menu to open Contact us page
            var contactUsButtonLocator = By.XPath("//*[text()='Contact us']");
            Click(contactUsButtonLocator);
            // Verify the title of the form is “CUSTOMER SERVICE - CONTACT US”
            //var customerServiceTitleLocator = B




        }

        // Find and click elems
        public void Click(By by)
        {
            IWebElement e = _driver.FindElement(by);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            e.Click();
        }
        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}