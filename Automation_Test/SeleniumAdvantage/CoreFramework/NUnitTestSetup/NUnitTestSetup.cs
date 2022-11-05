using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using CoreFramework.DriverCore;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CoreFramework.NUnitTestSetup
{
    public class NUnitTestSetup
    {
        // Check why [SetUp] uses InitDriver
        // Check Add Project Preference 
        public IWebDriver? _driver;
        public WebDriverAction? driverBaseAction;
        protected ExtentReports? _extentReport;
        protected ExtentTest? _extentTestSuite;
        protected ExtentTest? _extentTestCase;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _extentReport = new ExtentReports();
            string reportPath = TestContext.CurrentContext.TestDirectory;
            var reporter = new ExtentHtmlReporter($"{reportPath}\\Reports\\" +
                $"Report-{DateTime.UtcNow.ToString("yyyy_MM_dd_HH_mm_ss")}\\");
            // Generate a report
            _extentReport.AttachReporter(reporter);
            _extentTestSuite = _extentReport.CreateTest($"{TestContext.CurrentContext.Test.ClassName}");
        }

        [SetUp]
        public void SetUp()
        {
            WebDriverManager_.InitDriver("chrome", 1920, 1080);
            _driver = WebDriverManager_.GetCurrentDriver();
            _extentTestCase = _extentTestSuite.CreateNode
                ($"{TestContext.CurrentContext.Test.Name}");
            driverBaseAction = new WebDriverAction(_driver, _extentTestCase);
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            // Report results on ExtentRep
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus.Equals(TestStatus.Passed))
            {
                _extentTestCase?.Pass($"[Passed] Test {TestContext.CurrentContext.Test.Name}");

            }
            else if (testStatus.Equals(TestStatus.Failed))
            {
                // Unfinished error message TestExecution?
                _extentTestCase?.Fail($"[Failed] Test {TestContext.CurrentContext?.Test.Name}" +
                    $"because of the error \n");
            }
            // Delete?
            _extentReport.Flush();
        }
    }
}
