using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;
using Nunit.POM;

//‒ Create a Project using Selenium (C#) and Nunit
//‒ Convert Project to Page Object Design with following steps:
//1.Going to Google Search home page
//2. Input any text to search
//3. Reach to result screen, verify Title of this screen is matching with text in step 2
//4. Click on 1st result, verify any text in this screen
namespace Nunit 
{
    [TestClass]
    public class GoogleTest
    {
        // Vars
        protected WebDriverWait? _wait;
        protected IWebDriver? _driver;
        protected string GOOGLE_URL = "https://www.google.com/";
        protected string SEARCH_INPUT = "reddit";
        protected string SIGNUP_TEXT = "Sign Up";
        // Locators
        private By searchBox = By.XPath("//*[contains(@title,'Tìm kiếm')]");

        // Locators for requirement 4 (line 13)
        //private By firstResult = By.TagName("h3");
        //private By signUpBtn = By.XPath("//*[contains(@href,'https://www.reddit.com/register/?dest=https%3A%2F%2Fwww.reddit.com%2F')]");


        [SetUp]
        // Prepare chromedriver
        public void SetUp()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void TestHW()
        {
            //1.Going to Google Search home page
            //2. Input any text to search
            _driver.Navigate().GoToUrl(GOOGLE_URL);
            _driver.Manage().Window.Maximize();
            HeaderPage headerPage = new HeaderPage(_driver);
            headerPage.Search(SEARCH_INPUT);
            headerPage.Enter(searchBox);

            //3. Reach to result screen, verify Title of this screen is matching with text in step 2
            string pageTitle = _driver.Title;
            string stringBeforeDash = pageTitle.Substring(0, pageTitle.IndexOf("-"));
            Assert.That(SEARCH_INPUT, Is.EqualTo(stringBeforeDash.Trim()));

            //4. Click on 1st result, verify any text in this screen
            //_driver.Click(page.linkToFirstResult());
            ////Assert.That(SIGNUP_TEXT, Is.EqualTo()
            
            // End test
            CleanUpTest();
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            _driver.Quit();
        }


    }
}