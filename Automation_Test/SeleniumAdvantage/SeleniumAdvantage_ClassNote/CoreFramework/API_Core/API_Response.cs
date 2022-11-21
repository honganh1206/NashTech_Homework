using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.IO;
using ServiceStack;

namespace CoreFramework.API_Core
{

    public class API_Response
    {    

        // ------------------------------- ATTRIBUTES -------------------------------

        public HttpWebResponse response;
        public string responseBody { get; set; }
        public string responseStatusCode { get; set; }

        public API_Response(HttpWebResponse response)
        {
            this.response = response;
            GetResponseBody();
            GetResponseStatusCode();
        }
        // ------------------------------- METHODS -------------------------------

        //public int GenerateID()
        //{
        //    var jsonData = JSON.parse(responseBody);
        //    System.Reflection.PropertyInfo pi = jsonData.GetType().GetProperty("todos");
        //    Array name = (Array)(pi.GetValue(0, null));
        //    int id = name[0].id;
        //    return id;

        //}
        public string GetResponseBody()
        {
            // recheck this
            responseBody = "";
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
                return responseBody;
            }

        }
        public string GetResponseStatusCode()
        {
            try
            {
                HttpStatusCode statusCode = ((HttpWebResponse)response).StatusCode;
                responseStatusCode = statusCode.ToString();
            }
            catch (WebException webException)
            {
                // In case of 4xx and 5xx throw a WebException
                responseStatusCode = ((HttpWebResponse)webException.Response).StatusCode.ToString();
            }
            return responseStatusCode;

        }
        //public string Constructor()
        //{

        //}
        //public string ExtractFromBody()
        //{

        //}
        

    }
}
