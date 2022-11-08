using System.Globalization;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CoreFramework.Reporter;


// KEYWORD-DRIVEN
namespace CoreFramework.DriverCore
{
    public class WebDriverAction
    {
        public IWebDriver driver;

        public WebDriverAction(IWebDriver driver)
        {

            // this. means to the current instance of the class
            this.driver = driver;
        }
        // ------------------------------- MOVEMENTS -------------------------------

        public void MoveForward()
        {
                // Capture Screenshot fail?
                driver.Navigate().Forward();

        }
        public void MoveBackward()
        {
                driver.Navigate().Back();

        }
        // ------------------------------- INTERACTING WITH ELEMENTS  -------------------------------

        public By GetXpath(string locator)
        {
            return By.XPath(locator);
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public IWebElement FindElementByXpath(string locator)
        {
            IWebElement e = driver.FindElement(GetXpath(locator));
            HighlightElem(e);
            return e;
        }
        public IList<IWebElement> FindElementsByXpath(string locator)
        {
            return driver.FindElements(GetXpath(locator));
        }
        // Two clicks fo different platforms
        public void Click(string locator)
        {
            // for retrying
            //var interval = 5;
            //var current = 1;
            try
            {
                FindElementByXpath(locator).Click();
                HtmlReport.Pass("Clicking on element [" + locator + "] passed");

            }
            catch (Exception excep)
            {
                HtmlReport.Fail("Clicking on element [" + locator + "] failed");
                throw excep;
            }
        }

        public void PressEnter(string locator)
        {
            try
            {
                FindElementByXpath(locator).SendKeys(Keys.Enter);
                HtmlReport.Pass("Press enter on element [" + locator + "] passed");

            }
            catch (Exception excep)
            {
                HtmlReport.Fail("Press enter on element [" + locator + "] failed");
                throw excep;
            }
        }
        public void ClearSearchBox(string locator)
        {
            try
            {
                FindElementByXpath(locator).Clear();
                HtmlReport.Pass("Clear previous input in element [" + locator + "] passed");

            }
            catch (Exception excep)
            {
                HtmlReport.Fail("Clear previous input in element [" + locator + "] failed");
                throw excep;
            }
        }
        public void Click(IWebElement e)
        {
            try
            {
                HighlightElem(e);
                e.Click();
                HtmlReport.Pass("Clicking on element [ " + e.ToString() + " ] passed");
            }
            catch (Exception excep)
            {
                HtmlReport.Fail("Clicking on element [ " + e.ToString() + " ] failed");
                throw excep;
            }
        }

        public void SendKeys_(IWebElement e, string key)
        {
            // Param IWebElem
            try
            {
                e.SendKeys(key);
                HtmlReport.Pass("Sendkey into element " + e.ToString + " successfuly", TakeScreenShot());

            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Sendkey into element " + e.ToString + " failed");
                throw ex;
            }
        }

        public void SendKeys_(string locator, string key)
        {
            // Param string locator
            try
            {
                FindElementByXpath(locator).SendKeys(key);
                HtmlReport.Pass("Sendkeys to element [" + locator + "] passed", TakeScreenShot());
            }
            catch (Exception excep)
            {
                HtmlReport.Fail("Sendkeys to element [ " + locator + " ] failed", TakeScreenShot());
                throw excep;
            }
        }

        public IWebElement HighlightElem(IWebElement e)
        {
            try
            {
                IJavaScriptExecutor jsDriver = (IJavaScriptExecutor)driver;
                string highlightJavascript = "arguments[0].style.border='2px solid red'";
                jsDriver.ExecuteScript(highlightJavascript, new object[] { e });
                HtmlReport.Pass("Highlight element [" + e.ToString() + "] passed");
                return e;

            }
            catch (Exception excep)
            {
                HtmlReport.Fail("Highlight element [" + e.ToString() + "] failed");
                throw excep;

            }
        }

        public string GetTextFromElem(string locator)
        {
            return driver.FindElement(By.XPath(locator)).Text;
        }
        public void SelectOption(string locator, string key)
        {
            try
            {
                IWebElement mySelectOption = FindElementByXpath(locator);
                SelectElement dropdown = new SelectElement(mySelectOption);
                dropdown.SelectByText(key);
                TestContext.WriteLine("Select element " + locator + " successfuly with " + key);
            }
            catch (Exception excep)
            {
                TestContext.WriteLine("Select element " + locator + " failed with " + key);
                throw excep;
            }
        }
        public void Assert_(string actual, string expected)
        {

            try
            {
                Assert.That(actual, Is.EqualTo(expected));
                HtmlReport.Pass("Actual result [" + actual + "] " +
                    "is the same as [" + expected + "]");
            }
            catch (Exception excep)
            {
                HtmlReport.Fail("Actual result [" + actual + "] " +
                    "is not the same as [" + expected + "]");
                throw excep;

            }

        }

        // ------------------------------- CAPTURE SCREENSHOT  -------------------------------

        public void TakeScreenShot(string filePath)
        {
            // Old version (No HtmlReporter + 1 function to get Time stamp)
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(filePath + "//Chrome_" + GetDateTimeStamp() + ".png", ScreenshotImageFormat.Png);
                TestContext.WriteLine("Take screenshot successfully");
            }
            catch (Exception excep)
            {
                TestContext.WriteLine("Take screenshot failed");
                throw excep;
            }
        }

        public string TakeScreenShot()
        {
            // new version (Yes HtmlReporter)
            try
            {

                string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" +
                    DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png"; // Dynamic name
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(path, ScreenshotImageFormat.Png);
                HtmlReport.Pass("Take screenshot successfully");
                return path;
            }
            catch (Exception excep)
            {
                HtmlReport.Fail("Take screenshot failed");
                throw excep;
            }

        }
        public void TakeScreenshotIf404()
        {
            if (driver.Title.Contains("404"))
            {
                TakeScreenShot();
                HtmlReport.Warning("Error 404 - Screenshot taken");
            }
            TakeScreenShot();
        }
        // ------------------------------- NAMING  -------------------------------
        public string GetDateTimeStamp()
        {
            // Get creation time for photos in VN time zone
            var VNCulture = new CultureInfo("vi-VN");
            // get current UTC time
            var utcDate = DateTime.UtcNow;
            // Change time to match VN time
            var VNDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcDate, "SE Asia Standard Time");
            // output the GMT+7 time in Vietnam
            string currentTimeVN = VNDate.ToString("yyyy_MM_dd_HH_mm_ss", VNCulture);
            //string currentTimeVN = DateTime.UtcNow.ToString("yyyy_MM_dd_HH_mm_ss");
            return currentTimeVN;
        }



    }
}
