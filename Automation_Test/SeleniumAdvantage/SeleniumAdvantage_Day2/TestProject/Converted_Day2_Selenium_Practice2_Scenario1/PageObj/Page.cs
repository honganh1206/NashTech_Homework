using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace SeleniumAdvantage_Day2.Converted_Day2_Selenium_Practice2_Scenario1.PageObj
{
    public class Page : WebDriverAction
    {
        public Page(IWebDriver? driver) : base(driver)
        {
        }
        private readonly string contactUsBtnLocator = "//*[text()='Contact us']";
        private readonly string csTitleLocator = "//*[contains(@class, 'page-heading')]";
        public void VerifyText(string expectedText)
        {
            Assert_(GetTextFromElem(csTitleLocator), expectedText);
        }
        public void ClickBtn()
        {
            Click(contactUsBtnLocator);
        }

        public void VerifyPageTitle(string expectedpageTitle)
        {
            Assert_(GetTitle(), expectedpageTitle);
        }

    }

}
