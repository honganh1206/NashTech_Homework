using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using CoreFramework.DriverCore;

namespace CoreFramework.NUnitTestSetup
{
    public class NUnitTestSetup
    {
        // Check why [SetUp] uses InitDriver
        // Check Add Project Preference 
        public IWebDriver? _driver;
        public WebDriverAction? driverBaseAction;

        [SetUp]
        public void SetUp()
        {
            WebDriverManager_.InitDriver("chrome", 1920, 1080);
            _driver = WebDriverManager_.GetCurrentDriver();
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus.Equals(TestStatus.Passed))
            {
                TestContext.WriteLine("Passed");
            }
            else if (testStatus.Equals(TestStatus.Failed))
            {
                TestContext.WriteLine("Failed");
                driverBaseAction.TakeMultipleScreenShots();
            }
        }
    }
}
