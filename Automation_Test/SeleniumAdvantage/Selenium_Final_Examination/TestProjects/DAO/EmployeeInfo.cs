using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookiesTest.DAO
{
    public partial class ListOfEmployees
    {
        public List<EmployeeInfo> Employees { get; set; }
    }

    public partial class EmployeeInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
        public string Department { get; set; }

        public EmployeeInfo(string firstName, string lastName, 
            string age, string email, string salary, string department)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            Salary = salary;
            Department = department;
        }
    }
}
