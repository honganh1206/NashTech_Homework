using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace RookiesTest.PageObj
{
    public class MenuBarLeft : WebDriverAction
    {
        public MenuBarLeft(IWebDriver driver): base(driver)
        {

        }

        private string btnWebTables = "//span[text()='Web Tables']";

        public void GoToWebTablesPage()
        {
            Click(btnWebTables);

        }
    }
}
