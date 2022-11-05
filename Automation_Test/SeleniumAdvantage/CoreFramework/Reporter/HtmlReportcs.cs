using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;

namespace CoreFramework.Reporter
{
    internal class HtmlReportcs
    {
        public static void MarkUpHtml()
        {
            var htmlMarkUp = HtmlInjector.CreateHtml();
            var m = MarkupHelper.CreateLabel(htmlMarkUp, ExtentColor.Transparent);
            GetTest().Info(m);
        }
        public static void MarkupPassJson()
        {
            var json = "{'foo':'bar':'foos':['b','a','r'], " +
                "'bar':{'foo':'bar', 'bar':false, 'foobar':1234}}";
            GetTest().Info(MarkupHelper.CreateCodeBlock(json, CodeLanguage.Json));
        }
    }
}
