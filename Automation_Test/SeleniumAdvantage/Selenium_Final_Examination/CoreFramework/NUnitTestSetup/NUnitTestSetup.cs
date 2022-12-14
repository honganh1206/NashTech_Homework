using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using CoreFramework.DriverCore;
using AventStack.ExtentReports;
using CoreFramework.Reporter;

namespace CoreFramework.NUnitTestSetup
{
    public class NUnitTestSetup
    {
        // Check why [SetUp] uses InitDriver
        // Check Add Project Preference 
        public IWebDriver? _driver;
        public WebDriverAction? driverBaseAction;
        protected ExtentReports? _extentReport;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            HtmlReport.createReport();

            // Without this, a suite will not be created
            // Assign metadata here
            HtmlReport.createTest(TestContext.CurrentContext.Test.ClassName).
                AssignAuthor("Hong Anh Pham").AssignDevice("PC").AssignCategory("Selenium Final Test");
        }

        [SetUp]
        public void SetUp()
        {
            // Pass before initialization => Null
            // Need a parent obj (Test) before creating child objs (Node/Case)
            HtmlReport.createNode(TestContext.CurrentContext.Test.ClassName, 
                TestContext.CurrentContext.Test.Name);
            WebDriverManager_.InitDriver("chrome", 1920, 1080);
            _driver = WebDriverManager_.GetCurrentDriver();

            driverBaseAction = new WebDriverAction(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            // Report results on ExtentRep
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus.Equals(TestStatus.Passed))
            {

            }
            else if (testStatus.Equals(TestStatus.Failed))
            {
                // Unfinished error message TestExecution?
            }
            // Delete?
            HtmlReport.flush();
        }
    }
}
