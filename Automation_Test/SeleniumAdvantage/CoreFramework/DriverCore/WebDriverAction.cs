using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


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
        private WebDriverWait explicitWait;

        public WebDriverAction(IWebDriver driver)
        {

            // check this. in c#
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
        public void SendKeys_(IWebElement e, String key)
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
        public void SendKeys_(String locator, String key)
        {
            try
            {
                FindElementByXpath(locator).SendKeys(key);
                TestContext.WriteLine("Sendkeys to element [" + locator + "] passed");

            }
            catch (Exception excep)
            {
                TestContext.WriteLine("Sendkeys to element [" + locator + "] failed");
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
                string highlightJavascript = @"$(arguments[0]).css({ ""border-width"" : 
                        ""2px"", ""border-style"" : ""solid"", ""border-color"" : ""red"" });";
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

        public void ScreenShot()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile($"D://NashTech//Rookies//NashTech_Homework//Automation_Test" +
                $"//SeleniumAdvantage//RookiesTest//" +
                $"bin//Screenshot//Firefox.png", ScreenshotImageFormat.Png);
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
