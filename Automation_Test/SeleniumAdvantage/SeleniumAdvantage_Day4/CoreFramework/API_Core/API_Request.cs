using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CoreFramework.Reporter;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ServiceStack;

namespace CoreFramework.API_Core
{
    /* TODO
    - 4 methods of API Response = 4 functions (GET/POST/PUT/DELETE)
    - Check có Body hay không
    - CreateAPIRequestLog thay cho MarkUpJSON trong Report?

    */

    public class API_Request
    {

        // ------------------------------- WORKING WITH URL -------------------------------

        public HttpWebRequest request;
        public string url { get; set; }
        public string requestBody { get; set; }
        public string formData { get; set; }



        public API_Request()
        {
            url = "";
            requestBody = "";
            formData = "";
        }
        public API_Request(string baseUrl)
        {
            this.url = baseUrl;
            requestBody = "";
            formData = "";
        }
        // ------------------------------- REQUEST ACTIONS -------------------------------


        /////// ADD

        public API_Request AddHeader(string key, string value)
        {
            request.Headers.Add(key, value);
            return this;
        }

        public API_Request AddFormData(string key, string value)
        {
            if(formData.Equals("") || formData == null)
            {
                formData += key + "=" + value;
            }
            else if (!formData.Equals(""))
            {
                formData += "&" + key + "=" + value;
            }
            return this;
        }
        //public API_Request AddGETParam()
        //{

        //}

        /////// SET 
        public API_Request SetBody(string body)
        {
            this.requestBody = body;
            return this;
        }
        public API_Request SetURL(string url)
        {
            this.url = url;
            request = (HttpWebRequest)WebRequest.Create(url);
            return this;
        }

        public API_Request SetRequestParameter(string key, string value)
        {
            if (url.Contains("?"))
            {
                url += "?" + key + "=" + value;
            }
            else
            {
                // If there is already a parameter
                url += "&" + key + "=" + value;
            }
            return this;
        }
        public string SetMethod(string method)
        {
            switch (method)
            {
                case "GET":
                    request.Method = "GET";
                    break;
                case "POST":
                    request.Method = "POST";
                    break;
                case "PUT":
                    request.Method = "PUT";
                    break;
                case "DELETE":
                    request.Method = "DELETE";
                    break;
            }
            return request.Method;
               
        }
        public API_Response SendRequest()
        {
            if (request.Method == "GET")
            {
                requestBody = null;
            }
            else
            {
                if (requestBody != null)
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Flush();
                        dataStream.Close();
                    }
                }
                if (!formData.Equals(""))
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(formData);
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Flush();
                        dataStream.Close();
                    }
                }
            }
            try
            {
                IAsyncResult asyncResult = request.BeginGetResponse(null, null);
                asyncResult.AsyncWaitHandle.WaitOne();

                // Request 4 postman assignment went wrong here?
                var httpResponse = (HttpWebResponse)request.EndGetResponse(asyncResult);
                API_Response response = new API_Response(httpResponse);
                HtmlReport.CreateAPIRequestLog_(this, response);
                HtmlReport.MarkupPassJson(response.responseBody);
                return response;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public API_Response Get()
        {
            request.Method = "GET";
            API_Response response = SendRequest();
            return response;
        }
        public API_Response Post()
        {
            request.Method = "POST";
            API_Response response = SendRequest();
            return response;
        }
        public API_Response Put()
        {
            request.Method = "PUT";
            API_Response response = SendRequest();
            return response;
        }
        public API_Response Delete()
        {
            request.Method = "DELETE";
            API_Response response = SendRequest();
            return response;
        }
    }
}

