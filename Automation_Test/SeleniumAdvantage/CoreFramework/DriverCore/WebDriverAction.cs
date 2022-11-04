using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;


// KEYWORD-DRIVEN
namespace CoreFramework.DriverCore // HomePage inherits WebDriverAction
{
    // similar to page obj
    // Click method uses try/catch
    // Ctrl A and Command A in Mac
    // TestContext.Write() to notify try/catch

    // Highlight an elem = Add Style in CSS in FindElem method
    // Recheck AsyncLocal (for SimpleTest)


    public class WebDriverAction
    {
        public IWebDriver driver;
        protected ExtentTest? _extentTestCase;

        public WebDriverAction(IWebDriver driver, ExtentTest _extentTestCase)
        {

            // check this. in c#
            this.driver = driver;
            this._extentTestCase = _extentTestCase;
        }

        // return elems and elems' components
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
                TestContext.WriteLine("Clicking on element [" + locator + "] passed");

            }
            catch (Exception excep)
            {
                TestContext.WriteLine("Clicking on element [" + locator + "] failed");
                throw excep;
            }
        }
        public void Click(IWebElement e)
        {
            try
            {
                HighlightElem(e);
                e.Click();
                TestContext.WriteLine("Clicking on element [" + e.ToString() + "] passed");
            }
            catch (Exception excep)
            {
                TestContext.WriteLine("Clicking on element [" + e.ToString() + "] failed");
                throw excep;
            }
        }
        public void SendKeys_(IWebElement e, string key)
        {
            try
            {
                e.SendKeys(key);
                TestContext.WriteLine("Sendkey into element " + e.ToString + " successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Sendkey into element " + e.ToString + " failed");
                throw ex;
            }
        }
        public void SendKeys_(string locator, string key)
        {
            try
            {
                FindElementByXpath(locator).SendKeys(key);
                _extentTestCase.Pass("Sendkeys to element [" + locator + "] passed");

            }
            catch (Exception excep)
            {
                _extentTestCase.Fail("Sendkeys to element [" + locator + "] failed");
                throw excep;
            }
        }
        // Add more actions

        // TODO: Add SelectOption from a Toan's
        public IWebElement HighlightElem(IWebElement e)
        {
            try
            {
                IJavaScriptExecutor jsDriver = (IJavaScriptExecutor)driver;
                string highlightJavascript = "arguments[0].style.border='2px solid red'";
                jsDriver.ExecuteScript(highlightJavascript, new object[] { e });
                TestContext.WriteLine("Highlight element [" + e.ToString() + "] passed");
                return e;

            }
            catch (Exception excep)
            {
                TestContext.WriteLine("Highlight element [" + e.ToString() + "] failed");
                throw excep;

            }
        }

        public string GetTextFromElem(string locator)
        {
            return driver.FindElement(By.XPath(locator)).Text;
        }
        /* 
         Take multiple screenshots
         1. (Done - in WebDriverAction) Put your screenshot code into a function.
         2. (Where?Add a date time stamp to your screenshot filename to give each file a unique name.
         3. Add a short error string to the screenshot filename. 
            That will enable you to quickly see how many of each error type are present. 
        (Bonus) points for creating a folder for each error type 
        and only placing screenshots of that particular error in that folder.
         
         */
        public void TakeScreenShot(string filePath)
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(filePath + "//Chrome_" + GetDateTimeStamp() + ".png", ScreenshotImageFormat.Png);
                //TestContext.WriteLine("Take screenshot successfully");
            }
            catch (Exception excep)
            {
                TestContext.WriteLine("Take screenshot failed");
                throw excep;
            }

        }
        public void TakeMultipleScreenShots()
        {
            string imageOutputPath = "D://NashTech//Rookies//" +
                    $"NashTech_Homework//Automation_Test//SeleniumAdvantage//" +
                    $"CoreFramework//Reporter//Screenshots//";
            if (driver.Title.Contains("404"))
            {
                TakeScreenShot(imageOutputPath);
                TestContext.WriteLine("Error 404 - Screenshot taken");
            }
            else
            {
                TakeScreenShot(imageOutputPath);
                TestContext.WriteLine("Take screenshot successfully");
            }
        }
        public string GetDateTimeStamp()
        {
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

        // action select option
        public void SelectOption(String locator, String key)
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
    }
}
