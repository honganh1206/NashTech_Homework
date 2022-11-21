using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookiesTest.Services
{
    public class UserLoginDTO
    {
            public int id { get; set; }
            public string username { get; set; }
            public int password { get; set; }
            public string Token { get; set; }
     
    }
}
