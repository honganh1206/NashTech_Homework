using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


// KEYWORD-DRIVEN
namespace TestProject1.DriverCore // HomePage inherits WebDriverAction
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

        public string getTitle()
        {
            return driver.Title;
        }

        public IWebElement FindElementByXpath(string locator)
        {
            return driver.FindElement(GetXpath(locator));
        }
        // Two clicks fo different platforms
        public void Click(string locator)
        {
            try
            {
                FindElementByXpath(locator).Click();
                TestContext.WriteLine("Clicking on element [" + locator.ToString() + "] passed");

            }
            catch (Exception excep)
            {
                TestContext.WriteLine("Clicking on element [" + locator.ToString() + "] failed");
                throw excep;
            }
        }
        public void Click(IWebElement e)
        {
            try
            {
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
            }
            catch (Exception excep)
            {
                throw excep;
            }
        }
    }
}
