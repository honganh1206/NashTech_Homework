using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.API_Core;
using Newtonsoft.Json;

namespace RookiesTest.Services
{

    public class RookieAPILoginService 
    {
        public string userLoginPath = "/userslogin";

        public API_Response LoginRequest(string username, string password)
        {
            API_Response response = new API_Request()
                    .SetURL("https://www.saucedemo.com/")
                   .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                   .AddFormData("username", username)
                   .AddFormData("password", password)
                   .SendRequest();
            return response;

        }

        public RookieUserLoginDTO Login(string username, string password)
        {
            API_Response response = LoginRequest(username, password);
            RookieUserLoginDTO userLogin = (RookieUserLoginDTO)JsonConvert.DeserializeObject
                <RookieUserLoginDTO>(response.responseBody);
            return userLogin;

        }
    }



}
