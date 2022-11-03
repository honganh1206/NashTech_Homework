using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace CoreFramework.DriverCore
{
    // CreateLocalDriver and CreateBrowserStack
    // Check app config for nuget packages
    // Local and Browserstack
    internal class WebDriverCreator
    {
        // Receive params to open browsers
        public static IWebDriver? CreateLocalDriver(string Browser, 
            int ScreenWidth, int ScreenHeight)
        {
            IWebDriver? Driver = null;
            if (Browser.SequenceEqual("firefox"))
            {
                Driver = new FirefoxDriver();
            }
            else if (Browser.SequenceEqual("chrome"))
            {
                Driver = new ChromeDriver();
            }
            else if (Browser.SequenceEqual("safari"))
            {
                Driver = new SafariDriver();
            }
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Size = new Size(ScreenWidth, ScreenHeight);
            return Driver;
        }
        //public static IWebDriver? CreateBrowserstack(string Browser,
        //    int ScreenWidth, int ScreenHeight)
        //{
        //    IWebDriver? Driver = null;
        //    // Assign different drivers for each browser
        //    if (Browser.SequenceEqual("firefox"))
        //    {
        //        //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
        //        Driver = new FirefoxDriver();
        //    }
        //    else if (Browser.SequenceEqual("chrome"))
        //    {
        //        //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        //        Driver = new ChromeDriver();
        //    }
        //    else if (Browser.SequenceEqual("safari"))
        //    {
        //        //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        //        Driver = new SafariDriver();
        //    }
        //    // commands after starting driver
        //    Driver.Manage().Window.Maximize();
        //    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    Driver.Manage().Window.Size = new Size(ScreenWidth, ScreenHeight);
        //    return Driver;
        //}



    }
}
