using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.API_Core;
using Newtonsoft.Json;
using RookiesTest.TestSetup;

namespace RookiesTest.Services
{

    public class APIToDoService 
    {
        public string userLoginPath = "/v1/Login";

        public API_Response LoginRequest(string username, string password)
        {
            API_Response response = new API_Request()
                    .SetURL(Constant.LOGIN_API_URL)
                   .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                   .AddFormData("username", username)
                   .AddFormData("password", password)
                   .SendRequest();
            return response;

        }

        //public RookieUserLoginDTO Login(string username, string password)
        //{
        //    API_Response response = LoginRequest(username, password);
        //    RookieUserLoginDTO userLogin = (RookieUserLoginDTO)JsonConvert.DeserializeObject
        //        <RookieUserLoginDTO>(response.responseBody);
        //    return userLogin;

        //}
        public string getTodoPath = "/todos{0}"; // Solution to bug 1 in Auto sheet? - String format

        public API_Response GetTodoRequest(string todoId)
        {
            // To be re-used
            string requestPath = string.Format(getTodoPath, todoId);
            //TestContext.WriteLine(Constant.API_HOST + requestPath); // Fix 404 not found?
            API_Response response = new API_Request()
                .SetURL(Constant.API_HOST + requestPath)
                .Get();
            return response;
        }

    }



}
