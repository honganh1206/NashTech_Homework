using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;
using Nunit.POM;
using SeleniumExtras.WaitHelpers;

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
            Pages page = new Pages(_driver);
            HeaderPage headerPage = new HeaderPage(_driver);
            headerPage.Search(SEARCH_INPUT);
            headerPage.Enter();

            //3. Reach to result screen, verify Title of this screen is matching with text in step 2
            string pageTitle = _driver.Title;
            string stringBeforeDash = pageTitle.Substring(0, pageTitle.IndexOf("-"));
            Assert.That(stringBeforeDash.Trim(), Is.EqualTo(SEARCH_INPUT));

            //4. Click on 1st result, verify any text in this screen
            IWebElement getFirstResult = page.getFirstResult();
            getFirstResult.Click();

            IWebElement getSignUpBtn = page.getSignUpBtn();
            Assert.That(getSignUpBtn.Text, Is.EqualTo(SIGNUP_TEXT));
            
            // End test
            _driver.Close();
            CleanUpTest();
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            _driver.Quit();
        }


    }
}