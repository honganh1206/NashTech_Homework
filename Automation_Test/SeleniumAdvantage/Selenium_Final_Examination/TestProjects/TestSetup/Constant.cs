using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RookiesTest.DAO;

namespace RookiesTest.TestSetup
{
    public class Constant
    {
        public static string BASE_URL = "https://demoqa.com";
        public static int EMPLOYEE_NUM_1 = 1;
        public static int EMPLOYEE_NUM_2 = 2;
        public static int EMPLOYEE_NUM_3 = 3;

        public static EmployeeInfo EMPLOYEE_1 = new EmployeeInfo
            ("Cierra", "Vega", "39",
            "cierra@example.com", "10000", "Insurance");

        public static EmployeeInfo EMPLOYEE_2 = new EmployeeInfo
            ("Alden", "Cantrell", "45",
            "alden@example.com", "12000", "Compliance");

        public static EmployeeInfo EMPLOYEE_3 = new EmployeeInfo
            ("Kierra", "Gentry", "29",
            "kierra@example.com", "2000", "Legal");

        public static EmployeeInfo NEW_EMPLOYEE = new EmployeeInfo
            ("Van", "Nguyen", "29",
            "vannguyen@example.com", "1000", "Academia");

        public static EmployeeInfo UPDATED_EMPLOYEE = new EmployeeInfo
            ("Bob", "Gentry", "29",
            "kierra@example.com", "2000", "Legal");
    }
}
