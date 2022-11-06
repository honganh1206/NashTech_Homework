using System.Globalization;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CoreFramework.Reporter;


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

        public WebDriverAction(IWebDriver driver)
        {

            // this. means to the current instance of the class
            this.driver = driver;
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
        // Param IWebElem
        public void SendKeys_(IWebElement e, string key)
        {
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
        // Param string locator
        public void SendKeys_(string locator, string key)
        {
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
        // Add more actions

        // TODO: Add SelectOption from a Toan's
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
        /* 
         Take multiple screenshots
         1. (Done - in WebDriverAction) Put your screenshot code into a function.
         2. (Where?Add a date time stamp to your screenshot filename to give each file a unique name.
         3. Add a short error string to the screenshot filename. 
            That will enable you to quickly see how many of each error type are present. 
        (Bonus) points for creating a folder for each error type 
        and only placing screenshots of that particular error in that folder.
         
         */

        // Old version (No HtmlReporter + 1 function to get Time stamp)
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
        // new version (Yes HtmlReporter)
        public string TakeScreenShot()
        {
            try
            {
     
                string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" + 
                    DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png"; // Dynamic name
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(path, ScreenshotImageFormat.Png);
                //TestContext.WriteLine("Take screenshot successfully");
                return path;
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
            TakeScreenShot(imageOutputPath);
            TestContext.WriteLine("Take screenshot successfully");
        }
        // Get creation time for photos in VN time zone
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
    }
}
