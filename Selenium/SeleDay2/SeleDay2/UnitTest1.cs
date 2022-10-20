using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Assert = NUnit.Framework.Assert;

// SCENARIO 1
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
        protected string EXPECTED_FORM_TITLE = "CUSTOMER SERVICE - CONTACT US";
        protected string EXPECTED_PAGE_TITLE = "My Store"; // typo from "Store" to "store"
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
            IWebElement contactUsButton =  ReturnWebElement(contactUsButtonLocator);
            contactUsButton.Click();

            // Verify the title of the form is “CUSTOMER SERVICE - CONTACT US”
            var customerServiceTitlelocator = By.XPath("//*[contains(@class, 'page-heading')]");
            IWebElement customerServiceTitle = ReturnWebElement(customerServiceTitlelocator);
            Assert.That(customerServiceTitle.Text, Is.EqualTo(EXPECTED_FORM_TITLE));
            Console.WriteLine("Text Box Title validated successfully");

            // Come back to Home page (Use ‘Back’ command)
            _driver.Navigate().Back();
            // Verify the title of page is “My store”
            string pageTitle = _driver.Title;
            Assert.That(pageTitle, Is.EqualTo(EXPECTED_PAGE_TITLE));
            Console.WriteLine("Text Page Title validated successfully");

            // Again go back to Contact us page (This time use ‘Forward’ command)
            _driver.Navigate().Forward();

            // Close the Browser
            _driver.Close();

        }

        // Find and click elems
        public IWebElement ReturnWebElement(By by)
        {
            IWebElement e = _driver.FindElement(by);
            _wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions.ElementIsVisible(by));
            return e;
        }
        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}