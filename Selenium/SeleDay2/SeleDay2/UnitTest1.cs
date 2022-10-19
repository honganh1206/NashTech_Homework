using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

//• Launch the Chrome browser
//• Open website “http://automationpractice.com/index.php”
//• Print a Message to display that the website is opened successfully
//• Click to “Contact Us” link on top menu to open Contact us page
//• Verify the title of the form is “CUSTOMER SERVICE - CONTACT US”
//• Come back to Home page (Use ‘Back’ command)
//• Verify the title of page is “My store”
//• Again go back to Contact us page (This time use ‘Forward’ command)
//• Close the Browser

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
            var customerServiceTitlelocator = By.XPath("//*[text()='Customer service - Contact us");
            IWebElement customerServiceTitle = _driver.FindElement(customerServiceTitlelocator);
            _wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions.ElementIsVisible(customerServiceTitlelocator));
            string titleText = 




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