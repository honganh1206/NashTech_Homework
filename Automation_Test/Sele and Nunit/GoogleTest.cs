using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

//‒ Create a Project using Selenium (C#) and Nunit
//‒ Convert Project to Page Object Design with following steps:
//1.Going to Google Search home page
//2. Input any text to search
//3. Reach to result screen, verify Title of this screen is matching with text in step 2
//4. Click on 1st result, verify any text in this screen
namespace NunitPractice
{
    [TestClass]
    public class GoogleTest
    {
        // Vars
        protected WebDriverWait _wait;
        protected IWebDriver _driver;
        protected string GOOGLE_URL = "https://www.google.com/";
        protected string SEARCH_INPUT = "reddit";
        protected string SIGNUP_TEXT = "Sign Up";
        // Locators
        private By searchBar = By.XPath("//*[contains(@title,'Tìm kiếm')]");
        private By firstResult = By.TagName("h3");
        private By signUpBtn = By.XPath("//*[contains(@href,'https://www.reddit.com/register/?dest=https%3A%2F%2Fwww.reddit.com%2F')]");


        [SetUp]
        // prepare chromedriver
        public void SetUp()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        //1.Going to Google Search home page
        //2. Input any text to search
        public void EnterSearch()
        {
            _driver.Navigate().GoToUrl(GOOGLE_URL);
            _driver.Manage().Window.Maximize();
            IWebElement getSearchBar = ReturnWebElement(searchBar);
            getSearchBar.Clear();
            getSearchBar.SendKeys(SEARCH_INPUT);
            getSearchBar.SendKeys(Keys.Enter);
        }

        [Test]
        public void TestHW()
        {
            EnterSearch();
            //3. Reach to result screen, verify Title of this screen is matching with text in step 2
            string pageTitle = _driver.Title;
            string stringBeforeDash = pageTitle.Substring(0, pageTitle.IndexOf(" -"));
            Assert.That(SEARCH_INPUT, Is.EqualTo(stringBeforeDash));
            IWebElement getFirstResult = ReturnWebElement(firstResult);
            getFirstResult.Click();
            //4. Click on 1st result, verify any text in this screen
            IWebElement getSignUpBtnText = ReturnWebElement(signUpBtn);
            Assert.That(getSignUpBtnText.Text, Is.EqualTo(SIGNUP_TEXT));
            CleanUpTest();
        }

        // Find and click elems
        public IWebElement ReturnWebElement(By by)
        {
            IWebElement e = _driver.FindElement(by);
            //_wait.Until(SeleniumExtras.WaitHelpers.
            //    ExpectedConditions.ElementIsVisible(by));
            return e;
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            _driver.Quit();
        }


    }
}