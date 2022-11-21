using NUnit.Framework;
using RookiesTest.DAO;
using RookiesTest.PageObj;
using RookiesTest.TestSetup;
using Newtonsoft.Json;

namespace TestProject.TestCases
{
    [TestFixture]
    public class WebTablesPageTest : NUnitWebTestSetup
    {
        [Test]
        public void Scenario1()
        {
            // 1. Go to the application
            // 2. Select section: Element 
            // 3. On the Menu bar, select WebTable

            HomePage homePage = new HomePage(_driver);
            homePage.GoToElementsPage();
            MenuBarLeft menuBar = new MenuBarLeft(_driver);
            menuBar.GoToWebTablesPage();

            // 4. Verify WebTable screen is displayed
            WebTablesPage webTablesPage = new WebTablesPage(_driver);
            Assert.True(webTablesPage.IsHeaderDisplayed(), "WebTable screen is not displayed");
            TestContext.WriteLine("WebTable screen is displayed");
            //5. Given that there’re 3 employees existing in the system.
            //(you will see when go to the page)
            //-> verify the information of all employees is displayed correctly

            List<EmployeeInfo> actualListEmployees = webTablesPage.ReturnListEmployeeInfo();
            var actualListJSON = JsonConvert.SerializeObject(actualListEmployees);

            List<EmployeeInfo> expectedListEmployees = new List<EmployeeInfo>();
            expectedListEmployees.Add(Constant.EMPLOYEE_1);
            expectedListEmployees.Add(Constant.EMPLOYEE_2);
            expectedListEmployees.Add(Constant.EMPLOYEE_3);

            var expectedListJSON = JsonConvert.SerializeObject(expectedListEmployees);
            Assert.That(actualListJSON, Is.EqualTo(expectedListJSON));
            TestContext.WriteLine("The information of all employees is displayed correctly");
        }
        [Test]
        public void Scenario2()
        {
            // 1. Go to the application
            // 2. Select section: Element
            // 3. On the Menu bar, select WebTable

            HomePage homePage = new HomePage(_driver);
            homePage.GoToElementsPage();
            MenuBarLeft menuBar = new MenuBarLeft(_driver);
            menuBar.GoToWebTablesPage();
            // 4. Verify WebTable screen is displayed
            WebTablesPage webTablesPage = new WebTablesPage(_driver);
            Assert.True(webTablesPage.IsHeaderDisplayed(), "WebTable screen is not displayed");
            TestContext.WriteLine("WebTable screen is displayed");

            // 5. Click on Add
            webTablesPage.GoToRegistrationForm();

            // 6. Input valid data for a Employee and then click Submit

            AddNewRecord addNewRecordForm = new AddNewRecord(_driver);
            addNewRecordForm.InputNewEmployeeInfo(Constant.NEW_EMPLOYEE);
            addNewRecordForm.SubmitForm();

            // 7. Verify that new employee is added to new row in table with correct value you inputed
            List<EmployeeInfo> actualListEmployees = webTablesPage.ReturnListEmployeeInfo();
            EmployeeInfo newestEmployeeInfo = webTablesPage.GetNewestEmployee(actualListEmployees);

            var actualNewestEmployeeJSON = JsonConvert.SerializeObject(newestEmployeeInfo);
            var expectedNewestEmployeeJSON = JsonConvert.SerializeObject(Constant.NEW_EMPLOYEE);

            Assert.That(actualNewestEmployeeJSON, Is.EqualTo(expectedNewestEmployeeJSON));
            TestContext.WriteLine("New employee is added to new row in table with correct inputed value");

        }
        [Test]
        public void Scenario3()
        {
            // 1. Go to the application
            // 2. Select section: Element
            // 3. On the Menu bar, select WebTable

            HomePage homePage = new HomePage(_driver);
            homePage.GoToElementsPage();
            MenuBarLeft menuBar = new MenuBarLeft(_driver);
            menuBar.GoToWebTablesPage();
            // 4. Verify WebTable screen is displayed
            WebTablesPage webTablesPage = new WebTablesPage(_driver);
            Assert.True(webTablesPage.IsHeaderDisplayed(), "WebTable screen is not displayed");
            TestContext.WriteLine("WebTable screen is displayed");

            // 5. Click on button update of Employee name: Kierra
            webTablesPage.ClickEditBtn(Constant.EMPLOYEE_NUM_3);

            // 6.Update all information of that employee to new value and click submit
            AddNewRecord addNewRecordForm = new AddNewRecord(_driver);
            addNewRecordForm.ClearPreviousEmployeeInfo();
            addNewRecordForm.UpdateInfo(Constant.UPDATED_EMPLOYEE);
            addNewRecordForm.SubmitForm();


            List<EmployeeInfo> actualListEmployeesAfterUpdate = webTablesPage.ReturnListEmployeeInfo();
            EmployeeInfo updatedEmployeeInfo = webTablesPage.GetUpdatedEmployee
                (actualListEmployeesAfterUpdate, Constant.UPDATED_EMPLOYEE, Constant.EMPLOYEE_NUM_3);

            var actualUpdatedEmployeeJSON = JsonConvert.SerializeObject(updatedEmployeeInfo);
            var expectedUpdatedEmployeeJSON = JsonConvert.SerializeObject(Constant.UPDATED_EMPLOYEE);

            // 7. Verify data of that employee in the table is updated correctly with input data
            Assert.That(actualUpdatedEmployeeJSON, Is.EqualTo(expectedUpdatedEmployeeJSON));
            TestContext.WriteLine("Employee in the table is updated correctly with input data");
            // 8. Click delete that user
            webTablesPage.ClickDeleteBtn(Constant.EMPLOYEE_NUM_3);

            // 9. Verify that the user is no longer displayed in the table
            List<EmployeeInfo> actualListEmployeesAfterDelete = webTablesPage.ReturnListEmployeeInfo();

            List<EmployeeInfo> expectedListEmployeesAfterDelete = new List<EmployeeInfo>();
            expectedListEmployeesAfterDelete.Add(Constant.EMPLOYEE_1);
            expectedListEmployeesAfterDelete.Add(Constant.EMPLOYEE_2);

            var actualEmployeeAfterDeleteJSON = JsonConvert.SerializeObject(actualListEmployeesAfterDelete);
            var expectedEmployeeAfterDeleteJSON = JsonConvert.SerializeObject(expectedListEmployeesAfterDelete);
            Assert.That(actualEmployeeAfterDeleteJSON, Is.EqualTo(expectedEmployeeAfterDeleteJSON));
            TestContext.WriteLine("The user is no longer displayed in the table");

        }
    }

}
