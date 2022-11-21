using OpenQA.Selenium;
using CoreFramework.DriverCore;
using RookiesTest.DAO;
using ServiceStack;

namespace RookiesTest.PageObj
{
    public class CustomerSuccessPage : WebDriverAction
    {
        public CustomerSuccessPage(IWebDriver? driver) : base(driver)
        {
        }
        //private CustomerInfo CustomerName { get; set; }
        //private string fieldSibling = LocateField(customerName);
        //private string fieldToVerify = $@"//td[text()= '{fieldSibling}']//following-sibling::*[1]";
        private string nameLocator = $@"//td[text()= 'Customer Name']//following-sibling::*[1]";


        public string GetName()
        {
            return GetTextFromElem(nameLocator);
        }
        //public static string LocateField(CustomerInfo field)
        //{
        //    string fieldText; 
        //    CustomerInfo customerInfo;
        //    switch (customerInfo)
        //    {
        //        case field.Name:
        //            fieldText = 'Customer Name';
        //            return fieldText;

        //    }
        //}
    }
}
