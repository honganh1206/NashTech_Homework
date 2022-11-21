using AventStack.ExtentReports.MarkupUtils;
using CoreFramework.API_Core;
using ServiceStack;

namespace CoreFramework.Reporter.ExtentMarkup
{
    public class API_RequestLog : IMarkup
    {
        private API_Request request { get; set; }
        private API_Response response { get; set; }

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
                    <p>Response status: {response.responseStatusCode}</p>";
            return log;
        }
    }
}
