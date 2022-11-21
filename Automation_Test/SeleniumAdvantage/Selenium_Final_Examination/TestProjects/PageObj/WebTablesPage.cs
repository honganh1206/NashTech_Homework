using CoreFramework.DriverCore;
using OpenQA.Selenium;
using RookiesTest.DAO;
using RookiesTest.TestSetup;
using ServiceStack;

namespace RookiesTest.PageObj
{
    public class WebTablesPage : WebDriverAction
    {
        public WebTablesPage(IWebDriver driver): base(driver)
        {
        }


        // ------------------------------- SCENARIO 1 -------------------------------

        private string headerWebTables = "//div[contains(@class,'main-header')]";

        public bool IsHeaderDisplayed()
        {

            // Confirm if Web Tables header is displayed
            if (IsElementDisplay(headerWebTables) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public string GetRowIndex(int index)
        {
            // return an indexed row
            return rowLocator + "[" + index + "]" + cellLocator;
        }

        string rowLocator = "(//div[contains(@class, 'rt-tr ')])";

        public IList<IWebElement> GetAllRows()
        {
            IList<IWebElement> allRows = FindElementsByXpath(rowLocator);
            return allRows;
        }


        string cellLocator = "//div[contains(@role, 'gridcell')]";
        public IList<IWebElement> GetAllCellsFromOneRow(int index)
        {
            string indexRow = GetRowIndex(index);
            IList<IWebElement> allCellsInOneRow = FindElementsByXpath(indexRow);
            return allCellsInOneRow;
        }

        public EmployeeInfo GetTextFromEachCell(int index)
        {
            // Iterate through one row to get the text value
            List<string> valuesFromCells = new List<string>();
            IList<IWebElement> allCells = FindElementsByXpath(GetRowIndex(index)); // get all cells in a row
            foreach (IWebElement cell in allCells)
            {
                // go through each cell and add text values to a list of string
                valuesFromCells.Add(GetTextFromElem(cell));

            }
            // assign each value from cell to an EmployeeInfo object
            EmployeeInfo employee = new EmployeeInfo(
                valuesFromCells[0],
                valuesFromCells[1],
                valuesFromCells[2],
                valuesFromCells[3],
                valuesFromCells[4],
                valuesFromCells[5]
                );

            return employee;

        }

        public List<EmployeeInfo> ReturnListEmployeeInfo()
        {
            int i = 0;
            List<EmployeeInfo> listOfEmployees = new List<EmployeeInfo>();
            IList<IWebElement> allEmployeeRows = GetAllRows();

            foreach(IWebElement row in allEmployeeRows)
            {
                EmployeeInfo employee = GetTextFromEachCell(i + 1);
                listOfEmployees.Add(employee);
                i++;
            }
            foreach(EmployeeInfo employee in listOfEmployees.ToList())
            {
                // clear list elements from empty rows
                if(employee.FirstName.Contains(" "))
                {
                    listOfEmployees.Remove(employee);
                }
                else
                {
                    continue;
                }
            }
            return listOfEmployees;
        }

        // ------------------------------- SCENARIO 2 -------------------------------


        string btnAddNewRecord = "//button[contains(@id, 'addNewRecordButton')]";
        public void GoToRegistrationForm()
        {
            Click(btnAddNewRecord);
        }

        string btnEditEmployeeInfo = "(//span[@title = 'Edit'])";

        public EmployeeInfo GetNewestEmployee(List<EmployeeInfo> listOfEmployees)
        {
            EmployeeInfo newEmployee = listOfEmployees.LastOrDefault();
            return newEmployee;
        }

        // ------------------------------- SCENARIO 3 -------------------------------

        public void ClickEditBtn(int index)
        {
            Click(btnEditEmployeeInfo + "[" + index.ToString() + "]");
        }

        string btnDeleteEmployeeInfo = "(//span[@title = 'Delete'])";

        public void ClickDeleteBtn(int index)
        {
            Click(btnDeleteEmployeeInfo + "[" + index.ToString() + "]");
        }


        public static EmployeeInfo ReturnUpdatedEmployee(EmployeeInfo employee, int index)
        {
            switch (index)
            {
                case 1:
                    employee = Constant.EMPLOYEE_1;
                    break;
                case 2:
                    employee = Constant.EMPLOYEE_2;
                    break;
                case 3:
                    employee = Constant.UPDATED_EMPLOYEE;
                    break;
            }
            return employee;
        }
        public EmployeeInfo GetUpdatedEmployee(List<EmployeeInfo> listOfEmployees, 
            EmployeeInfo updatedEmployee, int index)
        {
            EmployeeInfo updatedEmployee_ = ReturnUpdatedEmployee(updatedEmployee, index);
            listOfEmployees = ReturnListEmployeeInfo();
            foreach (EmployeeInfo employee in listOfEmployees)
            {
                if (employee.FirstName == updatedEmployee_.FirstName)
                {
                    // get the updated employee by matching first name
                    updatedEmployee_ = employee;
                    break;

                }
                else
                {
                    continue;
                }
            }
            return updatedEmployee_;
        }


    }
}
