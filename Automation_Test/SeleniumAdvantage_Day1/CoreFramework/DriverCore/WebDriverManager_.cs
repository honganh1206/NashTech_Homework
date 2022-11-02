using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AutomationFramework.Config;

namespace TestProject1.DriverCore
{
    // public means visible from anywhere
    public class WebDriverManager_
    {
        // Noted Async in Obsi
        private static AsyncLocal<IWebDriver> driver = new AsyncLocal<IWebDriver>();

        public static void InitDriver(String Browser, int Width, int Height)
        {
            FrameworkConfiguration frameworkConfiguration = ConfigManager.
                GetConfig<FrameworkConfiguration>("Framework");
            IWebDriver newDriver = null;
            if(frameworkConfiguration.ExecuteLocation.Equals("local"))
            {
                newDriver = WebDriverCreator.CreateLocalDriver(Browser, Height, Width);
            }
            else if (frameworkConfiguration.ExecuteLocation.Equals("browserstack"))
            {
                newDriver = WebDriverCreator.CreateBrowserstackDriver(Browser, Width, Height);
            }

            if (newDriver != null)
            {
                throw new Exception($"{Browser} browser is not supported");
            }
            driver.Value = newDriver;

        }

        public static IWebDriver GetCurrentDriver()
        {

        }
    }
}
