using OpenQA.Selenium;
using CoreFramework.DriverCore;
using RookiesTest.DAO;

namespace RookiesTest.PageObj
{
    public class AddNewRecord : WebDriverAction
    {
        public AddNewRecord(IWebDriver? driver) : base(driver)
        {
        }

        private string tfFirstName = "//input[@id = 'firstName']";
        private string tfLastName = "//input[@id = 'lastName']";
        private string tfEmail = "//input[@id = 'userEmail']";
        private string tfAge = "//input[@id = 'age']";
        private string tfSalary = "//input[@id = 'salary']";
        private string tfDepartment = "//input[@id = 'department']";

        private string btnSubmit = "//button[@id = 'submit']";

        public void InputNewEmployeeInfo(EmployeeInfo newEmployee)
        {
            SendKeys_(tfFirstName, newEmployee.FirstName);
            SendKeys_(tfLastName, newEmployee.LastName);
            SendKeys_(tfEmail, newEmployee.Email);
            SendKeys_(tfAge, newEmployee.Age);
            SendKeys_(tfSalary, newEmployee.Salary);
            SendKeys_(tfDepartment, newEmployee.Department);
        }
        public void UpdateInfo(EmployeeInfo newEmployee)
        {
            SendKeys_(tfFirstName, newEmployee.FirstName);
        }

        public void ClearPreviousEmployeeInfo()
        {
            Clear(tfFirstName);
            Clear(tfLastName);
            Clear(tfEmail);
            Clear(tfAge);
            Clear(tfSalary);
            Clear(tfDepartment);
        }
        public void SubmitForm()
        {
            Click(btnSubmit);
        }
    }
}
