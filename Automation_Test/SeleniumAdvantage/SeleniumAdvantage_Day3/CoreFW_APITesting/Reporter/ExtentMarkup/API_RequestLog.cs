using System.Security.Cryptography;
using AventStack.ExtentReports.MarkupUtils;
using CoreFramework.API_Core;
using CoreFramework.Reporter;
using ServiceStack;
using ServiceStack.Text;

namespace CoreFramework.Reporter.ExtentMarkup
{
    public class API_RequestLog : IMarkup
    {
        private API_Request request { get; set; }
        private API_Response response { get; set; }
        // Hardcode
        //string _id = "code-block-json-1";
        public API_RequestLog(API_Request request, API_Response response)
        {
            this.request = request;
            this.response = response;

        }

        public string GetMarkup()
        {
            //  <p>Request body: {response.responseBody}</p> in the middle
            string log = $@"
                    <p>Request url: {request.url}</p>
                    <p>Response status: {response.responseStatusCode}</p>
                    <p>Response body: {response.responseBody}</p>";
            return log;
        }
    }
}

            //< div class= 'json-tree' id = 'code-block-json-" + _id + "' ></ div > " +
            //"<script>function jsonTreeCreate" + _id +
            //"() { document.getElementById('code-block-json-" + _id + "').innerHTML = " +
            //"JSONTree.create(" + response.responseBody + "); }jsonTreeCreate" + _id + "();</script>";
