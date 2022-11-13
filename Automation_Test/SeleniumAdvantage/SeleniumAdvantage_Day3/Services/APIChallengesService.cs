using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.API_Core;
using Microsoft.VisualBasic;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using static SeleniumAdvantage_Day3.Services.TodosDTO;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace SeleniumAdvantage_Day3.Services
{
    public class APIChallengesService
    {
        public string pathRequest04 = "/todo";

        public API_Response Request04()
        {
            API_Response response = new API_Request()
                   .SetURL("https://apichallenges.herokuapp.com" + pathRequest04)
                   .SendRequest();

            return response;


        }
        public string pathRequest05 = "/todos/934";
        public API_Response Request05()
        {
            API_Response response = new API_Request().
                   SetURL("https://apichallenges.herokuapp.com" + pathRequest05)
                   .SendRequest();
            return response;


        }
        public string pathRequest09 = "/todos";
        public API_Response Request09()
        {
            API_Response response = new API_Request().
                   SetURL("https://apichallenges.herokuapp.com" + pathRequest09)
                   .SetRequestParameter("doneStatus", "true")
                   .SendRequest();
            return response;


        }
        public string pathRequest8 = "/todos";
        public API_Response Request08()
        {
            var reqObj = new Todo();
            reqObj.Title = "create new todo";
            reqObj.DoneStatus = true;

            string requestBody = JsonConvert.SerializeObject(reqObj);
            

            API_Response response = new API_Request().
                   SetURL("https://apichallenges.herokuapp.com" + pathRequest8)
                   .SetBody(requestBody)
                   .SendRequest();
            return response;


        }

    }
}
