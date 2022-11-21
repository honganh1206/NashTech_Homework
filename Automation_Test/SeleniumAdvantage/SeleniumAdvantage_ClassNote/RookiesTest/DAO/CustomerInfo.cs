using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookiesTest.DAO
{
    public class CustomerInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }



        public CustomerInfo(string name, string address, string dOB)
        {
            Name = name;
            Address = address;
            DOB = dOB;
        }
    }
}
