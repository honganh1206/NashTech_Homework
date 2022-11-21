//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Remote;

//namespace RookiesTest.TestCases
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.Children)]
//    public class ParallelTests
//    {
//        [Test]
//        public void TestWithFirefox()
//        {
//            FirefoxOptions firefoxOptions = new FirefoxOptions();

//            WebDriver driver = RemoteWebDriver(new Uri("https://localhost:4444"), firefoxOptions);
//            driver.Navigate().GoToUrl("https://google.com");
//            var searchBox = driver.FindElement(By.CssSelector("[name='q'"));
//            if (searchBox != null)
//            {
//                searchBox.SendKeys("ABC");
//            }
//            // Sele command to take screenshot
//            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
//            ss.SaveAsFile($"D://NashTech//Rookies//NashTech_Homework//Automation_Test" +
//                $"//SeleniumAdvantage_Day1//Screenshots//Firefox.png", ScreenshotImageFormat.Png);
//            driver.Quit();
//        }

//        [Test]
//        public void TestWithChrome()
//        {
//            ChromeOptions chromeOptions = new ChromeOptions();
//            chromeOptions.AddArgument("start-maximized");
//            chromeOptions.AddArgument("disable-infobars");
//            chromeOptions.AddArgument("--disable-extensions");
//            chromeOptions.AddArgument("--disable-gpu");
//            chromeOptions.AddArgument("--disable-dev-shm-usage");
//            chromeOptions.AddArgument("--no-sandbox");
//            chromeOptions.AddArgument("--ignore-ssl-error=yes");
//            chromeOptions.AddArgument("--ignore-certificate-errors");

//            WebDriver driver = RemoteWebDriver(new Uri("https://localhost:4444"), chromeOptions);
//            driver.Navigate().GoToUrl("https://google.com");
//            var searchBox = driver.FindElement(By.CssSelector("[name='q'"));
//            if (searchBox != null)
//            {
//                searchBox.SendKeys("ABC");
//            }
//            // Sele command to take screenshot
//            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
//            ss.SaveAsFile($"D://NashTech//Rookies//NashTech_Homework//Automation_Test" +
//                $"//SeleniumAdvantage_Day1//Screenshots//Chrome.png", ScreenshotImageFormat.Png);
//            driver.Quit();

//        }
//    }
//}
