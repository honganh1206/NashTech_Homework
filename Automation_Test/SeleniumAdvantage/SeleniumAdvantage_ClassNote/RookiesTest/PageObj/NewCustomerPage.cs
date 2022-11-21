using OpenQA.Selenium;
using CoreFramework.DriverCore;
using RookiesTest.DAO;

namespace RookiesTest.PageObj
{
    public class NewCustomerPage : WebDriverAction
    {
        public NewCustomerPage(IWebDriver? driver) : base(driver)
        {
        }

        private string tfName = "//input[@name = 'name']";
        private string tfAddress = "//textarea[@name = 'addr']";
        private string tfDOB = "//input[@name = 'dob']";


        public void InputCustomerInfo(CustomerInfo validCustomer)
        {
            SendKeys_(tfName, validCustomer.Name);
            SendKeys_(tfAddress, validCustomer.Address);
            SendKeys_(tfDOB, validCustomer.DOB);



        }
    }
}
