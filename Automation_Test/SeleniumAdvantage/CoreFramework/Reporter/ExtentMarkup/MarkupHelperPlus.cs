using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.MarkupUtils;
using Microsoft.AspNetCore.Http;
using CoreFramework.API_Core;

namespace CoreFramework.Reporter.ExtentMarkup
{
    public class MarkupHelperPlus
    {
        public static IMarkup CreateAPIRequestLog(API_Request request, API_Response response)
        {
            return new API_RequestLog(request, response);
        }

    }
}
