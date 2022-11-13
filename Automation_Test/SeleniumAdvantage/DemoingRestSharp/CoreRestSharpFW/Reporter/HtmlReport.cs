using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using CoreFramework.Reporter.ExtentMarkup;
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
        

        // ------------------------------- CREATE EXTENTREPORT  -------------------------------

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
        // Pass with no screenshot
        public static void Pass(string des)
        {
            GetTest().Pass(des);
            TestContext.WriteLine(des);
            //HtmlReport.MarkupPassLabel(des);
        }
        // Pass with screenshot
        public static void Pass (string des, string path)
        {
            GetTest().Pass(des).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }
        // normal fail message
        public static void Fail(string des)
        {

            GetTest().Fail(des);
            TestContext.WriteLine(des);
        }

        // add path to screenshot
        public static void Fail(string des, string path)
        {

            GetTest().Fail(des).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }
        // add failed example? and path to screenshot
        public static void Fail (string des, string ex, string path)
        {

            GetTest().Fail(des).Fail(ex).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }

        // INFO
        //public static void Info(string des)
        //{
        //    GetTest().Info(des);
        //    TestContext.WriteLine(des);
        //}
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

        // ------------------------------- MARKUP  -------------------------------

        //public static void MarkUpHtml()
        //{
        // Inject HTML code to report
        //    var htmlMarkUp = HtmlInjector.CreateHtml();
        //    var m = MarkupHelper.CreateLabel(htmlMarkUp, ExtentColor.Transparent);
        //    /* Similar syntax to Java
        //     * return Log(Status.Info, m);
        //     */
        //    GetTest().Info(m);
        //}
        public static void MarkupPassJson()
        {
            var json = "{'foo':'bar':'foos':['b','a','r'], " +
                "'bar':{'foo':'bar', 'bar':false, 'foobar':1234}}";
            GetTest().Info(MarkupHelper.CreateCodeBlock(json, CodeLanguage.Json));
        }
        public static void MarkupTable()
        {
            string[][] someInts = new string[][] {
                new string[] {
                    "<label> HAHAHA </label>"}
            };
            var m = MarkupHelper.CreateTable(someInts);
            GetTest().Info(m);
        }
        // LABELS
        public static void MarkupPassLabel()
        {
            var text = "Passed";
            var m = MarkupHelper.CreateLabel(text, ExtentColor.Green);
            GetTest().Pass(m);
        }
        public static void MarkupFailLabel()
        {
            var text = "Failed";
            var m = MarkupHelper.CreateLabel(text, ExtentColor.Red);
            GetTest().Fail(m);
        }
        public static void MarkupWarningLabel()
        {
            var text = "Warning";
            var m = MarkupHelper.CreateLabel(text, ExtentColor.Orange);
            GetTest().Warning(m);
        }
        public static void MarkupSkipLabel()
        {
            var text = "Skipped";
            var m = MarkupHelper.CreateLabel(text, ExtentColor.Blue);
            GetTest().Skip(m);
        }
        public static void MarkupXML()
        {
            string code = "<root>" +
                    "\n    <Person>" +
                    "\n        <Name>Joe Doe</Name>" +
                    "\n        <StartDate>2007-01-01</StartDate>" +
                    "\n        <EndDate>2009-01-01</EndDate>" +
                    "\n        <Location>London</Location>" +
                "\n    </Person>                    " +
                "\n    <Person>" +
                    "\n        <Name>John Smith</Name>" +
                    "\n        <StartDate>2012-06-15</StartDate>" +
                    "\n        <EndDate>2014-12-31</EndDate>" +
                    "\n        <Location>Cardiff</Location>" +
                "\n    </Person>" +
            "\n</root>";
            var m = MarkupHelper.CreateCodeBlock(code, CodeLanguage.Xml);
            GetTest().Pass(m);
        }

        // ------------------------------- API  -------------------------------

        public static void CreateAPIRequestLog_(API_Request request, API_Response response)
        {
            GetTest().Info(MarkupHelperPlus.CreateAPIRequestLog(request, response));
        }
    }
}
