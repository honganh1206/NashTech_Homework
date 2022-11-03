using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestProject1.DriverCore
{
    // public means visible from anywhere
    public class WebDriverManager_
    {
        // Noted Async in Obsi
        private static AsyncLocal<IWebDriver> driver = new AsyncLocal<IWebDriver>();

        public static void InitDriver(String Browser, int Width, int Height)
        {
            //FrameworkConfiguration frameworkConfiguration = ConfigManager.
            //    GetConfig<FrameworkConfiguration>("Framework");
            IWebDriver newDriver = null;
            newDriver = WebDriverCreator.CreateLocalDriver(Browser, Height, Width);

            if (newDriver != null)
            {
                throw new Exception($"{Browser} br owser is not supported");
            }
            driver.Value = newDriver;

        }

        public static IWebDriver GetCurrentDriver()
        {
            return driver.Value;
        }

        public static void CloseDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
            }
        }
    }
}
