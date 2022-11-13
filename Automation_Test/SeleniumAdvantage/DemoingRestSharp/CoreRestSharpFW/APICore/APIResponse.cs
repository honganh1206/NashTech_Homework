using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace CoreRestSharpFW.APICore
{
    public class APIResponse
    {
        public RestResponse response;
        public string responseBody { get; set; }
        public string responseStatusCode { get; set; }

        public APIResponse(RestResponse response)
        {
            this.response = response;
            GetResponseBody();
            GetResponseStatusCode();
        }
        public APIResponse GetResponseBody()
        {
            // recheck this
            

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
    }
