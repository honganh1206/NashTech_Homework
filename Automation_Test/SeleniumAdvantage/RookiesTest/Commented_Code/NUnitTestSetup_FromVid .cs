//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Reporter;
//using OpenQA.Selenium.Chrome;
//using NUnit.Framework.Interfaces;
//using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol;
//using NUnit.Framework.Internal;
//using RookiesTest.PageObj;
//using NUnit.Framework;

//namespace RookiesTest.TestCases
//{
//    [TestFixture]
//    public class SimpleTests
//    {
//        // Setup
//        protected WebDriverWait? _wait;
//        protected IWebDriver? _driver;
//        protected ExtentReports? _extentReport;
//        protected ExtentTest? _extentTest;

//        [OneTimeSetUp]

//        public void OneTimeSetUp()
//        {
//            _extentReport = new ExtentReports();
//            string reportPath = TestContext.CurrentContext.TestDirectory;
//            var reporter = new ExtentHtmlReporter($"{reportPath}\\Reports\\" +
//                $"Report-{DateTime.UtcNow.ToString("yyyy_MM_dd_HH_mm_ss")}");
//            _extentReport.AttachReporter(reporter);
//              _extentTestSuite



//        }

//        [SetUp]

//        public void SetUp()
//        {
//            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
//            // Implicit wait?
//            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
//            _extentTest = _extentReport.CreateTest($"{TestContext.CurrentContext.Test.Name}");

//        }

//        [TearDown]
//        public void TearDown()
//        {
//            _driver?.Quit();
//            // Report results on ExtentRep
//            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
//            if (testStatus.Equals(TestStatus.Passed))
//            {
//                _extentTest?.Pass($"[Passed] Test {TestContext.CurrentContext.Test.Name}");

//            }
//            else if (testStatus.Equals(TestStatus.Failed))
//            {
//                // Unfinished error message TestExecution?
//                _extentTest?.Fail($"[Failed] Test {TestContext.CurrentContext?.Test.Name}" +
//                    $"because of the error \n");
//            }
//            // Delete?
//            _extentReport.Flush();

//        }
//        // provide arguments for each test case 
//        [TestCase(1)]
//        [TestCase(2)]
//        public void EqualsConparison(int comparedNumber)
//        {
//            _extentTest?.CreateNode($"Step 1 is doing something").Info("Step 1 is implemented");
//            _extentTest?.CreateNode($"Step 2 is doing something").Info("Step 2 is implemented");
//            _extentTest?.CreateNode($"Step 3 is doing something").Info("Step 3 is implemented");
//            //What??
//            Assert.IsTrue(comparedNumber == 1);
//        }

//        public void UserCanSearchVideos()
//        {
//            HomePage homePage = new HomePage(_driver);
//            homePage.InputSearchBox("ABC").ClickSearchButton().OpenVideo("Haha");
//        }

//        public int? GetRandomNumber()
//        {
//            return null;
//        }

//        public void CalculateAbc(string a)
//        {
//            Console.WriteLine(a);
//        }

//        [Test]

//        public void ElementsCommandTest()
//        {
//            // Element commands
//            _driver.Navigate().GoToUrl("https://youtube.com");
//            IList<IWebElement> tags = _driver.FindElements(By.XPath);
//        }
//    }
//}
