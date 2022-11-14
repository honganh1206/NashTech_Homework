using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace CoreRestSharpFW.APICore
{
    public class APIRequest
    {
        // ------------------------------- WORKING WITH URL/ATTRIBUTES -------------------------------

        public RestRequest request { get; set; }
        public RestClient client { get; set; }
        public string requestBody { get; set; }
        public string formData { get; set; }


        public APIRequest()
        {
            requestBody = "";
            formData = "";
        }
        public APIRequest(string baseUrl)
        {
            requestBody = "";
            formData = "";
        }

        public APIRequest AddHeader(string key, string value)
        {
            request.AddHeader(key, value);
            return this;
        }
        public APIRequest AddFormData(string key, string value)
        {
            if (formData.Equals("") || formData == null)
            {
                formData += key + "=" + value;
            }
            else if (!formData.Equals(""))
            {
                formData += "&" + key + "=" + value;
            }
            return this;
        }
        public APIRequest SetBody(string body)
        {
            this.requestBody = body;
            return this;
        }

        public APIRequest AddParameter(string key, string value)
        {
            request.AddHeader(key, value);
            return this;
        }

        public APIRequest SendGETRequest()
        {
            request = new RestRequest("get", Method.Get);
            return request;
        }
    }
}
