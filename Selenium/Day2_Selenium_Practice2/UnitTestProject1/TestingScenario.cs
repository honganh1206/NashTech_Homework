using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

namespace SeleniumPracticeDay2
{
    [TestFixture]
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
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Console.WriteLine("The website is opened successfully");

            // Click to “Contact Us” link on top menu to open Contact us page
            var contactUsButtonLocator = By.XPath("//*[text()='Contact us']");
            _wait.Until(
                ExpectedConditions.ElementIsVisible(contactUsButtonLocator));

        }
        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}
