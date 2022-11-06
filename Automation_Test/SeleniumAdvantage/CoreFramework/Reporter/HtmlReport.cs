using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;


namespace CoreFramework.Reporter
{
    internal class HtmlReport
    {
        // VARS
        private static int testCaseIndex;
        //private static string testCaseName;
        private static ExtentReports _report;
        private static ExtentTest extentTestSuite;
        private static ExtentTest extentTestCase;


        // ACTIONS
        // Tránh tạo report trùng => Luôn có 1 obj duy nhất
        public static ExtentReports createReport()
        {
            // Check if report is initialized
            // Many methods below do the same thing
            if (_report == null)
            {
                _report = createInstance();
            }
            return _report;
        }
        public static ExtentReports createInstance()
        {
            // Formatting
            HtmlReportDirectory.InitReportDirection(); // create a report folder
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter
                (HtmlReportDirectory.REPORT_FILE_PATH);
            htmlReporter.Config.DocumentTitle = "Automation Test Report";
            htmlReporter.Config.ReportName = "Automation Test Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.
                Configuration.Theme.Standard;
            htmlReporter.Config.Encoding = "UTF-8";

            // Create a report obj
            ExtentReports report = new ExtentReports();
            report.AttachReporter(htmlReporter);
            return report;
        }
        
        public static void flush()
        {
            if (_report != null)
            {
                _report.Flush();
            }
        }
        
        public static ExtentTest createTest(string className, string classDescription ="")
        {
            // Tạo 1 suite trong file HTML (cột bên trái)
            if (_report == null)
            {
                _report = createInstance();
            }
            extentTestSuite = _report.CreateTest(className, classDescription);
            return extentTestSuite; 
        }
        
        public static ExtentTest createNode(string className, string testcase, 
            string description = "")
        {
            // Tạo các cases trong suite (cột bên phải)
            if (extentTestSuite == null)
            {
                extentTestSuite = createTest(className);
            }
            extentTestCase = extentTestSuite.CreateNode(testcase, description);
            return extentTestCase;
        }

        public static ExtentTest GetParent()
        {
            return extentTestSuite;
        }


        public static ExtentTest GetNode()
        {
            return extentTestCase;
        }

        public static ExtentTest GetTest()
        {
            if (GetNode() == null)
            {
                return GetParent();
            }
            return GetNode();
        }

        // PASS OR FAIL
        public static void Pass (string des)
        {
            GetTest().Pass(des);
            TestContext.WriteLine(des);
        }
        public static void Fail(string des)
        {
            // Add a screenshot to the report

            GetTest().Fail(des);
            TestContext.WriteLine(des);
        }
        public static void Fail (string des, string ex, string path)
        {

            GetTest().Fail(des).Fail(ex).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }

        // INFO
        public static void Info(string des)
        {
            GetTest().Info(des);
            TestContext.WriteLine(des);
        }
        //public static void Info(HttpWebRequest request, HttpWebResponse response)
        //{
        //    GetTest().Info(MarkupHelperPlus.CreateRequest(request, response));
        //    // TestContext.Progress.WriteLine(des);
        //}
        public static void Warning (string des)
        {
            GetTest().Warning(des);
            TestContext.WriteLine(des);
        }
        public static void Skip(string des)
        {
            GetTest().Skip(des);
            TestContext.WriteLine(des);
        }


        // MARKUP
        //public static void MarkUpHtml()
        //{
        //    var htmlMarkUp = HtmlInjector.CreateHtml();
        //    var m = MarkupHelper.CreateLabel(htmlMarkUp, ExtentColor.Transparent);
        //    GetTest().Info(m);
        //}
        //public static void MarkupPassJson()
        //{
        //    var json = "{'foo':'bar':'foos':['b','a','r'], " +
        //        "'bar':{'foo':'bar', 'bar':false, 'foobar':1234}}";
        //    GetTest().Info(MarkupHelper.CreateCodeBlock(json, CodeLanguage.Json));
        //}
        //public static void MarkupTable()
        //{
        //    string[][] someInts = new string[][] {
        //        new string[] {
        //            "<label> HAHAHA </label>"} 
        //    };
        //    var m = MarkupHelper.CreateTable(someInts);
        //    GetTest().Info(m);
        //}
        //public static void MarkupLabel()
        //{
        //    var text = "extent";
        //    var m = MarkupHelper.CreateLabel(text, ExtentColor.Blue);
        //    GetTest().Pass(m);
        //}
    }
}
