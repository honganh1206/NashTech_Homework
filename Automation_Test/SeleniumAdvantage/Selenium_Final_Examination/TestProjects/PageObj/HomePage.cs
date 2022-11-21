using CoreFramework.DriverCore;
using OpenQA.Selenium;
using RookiesTest.TestSetup;

namespace RookiesTest.PageObj
{
    public class HomePage : WebDriverAction
    {
        public HomePage(IWebDriver driver) : base(driver) 
        { 
        }
        private string btnElements = "(//h5[text()='Elements'])";

        public void GoToElementsPage()
        {
            Click(btnElements);
        }

        private string addedUrl = "/elements";

        public bool IsCorrectRedirect()
        {
            if (Constant.BASE_URL + addedUrl == GetUrl())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
