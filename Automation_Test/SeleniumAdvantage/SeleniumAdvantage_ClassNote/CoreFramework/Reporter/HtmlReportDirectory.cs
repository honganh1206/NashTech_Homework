using CoreFramework.Utilities;

namespace CoreFramework.Reporter
{
    public class HtmlReportDirectory
    {
        // static vì khi chạy test nên có 1 report duy nhất 
        // Thay vì tạo nhiều folders với nhiều tên (Dynamic) thì chuyển thành 1 folder (static)
        public static string REPORT_ROOT { get; set;}
        public static string REPORT_FOLDER_PATH { get; set; }
        public static string REPORT_FILE_PATH { get; set; }
        public static string SCREENSHOT_PATH { get; set; }

        // For future lessons
        // Used for comparing between visual elements (Applitools?)
        public static string ACTUAL_SCREENSHOT_PATH { get; set; }
        public static string DIFFERENCE_SCREENSHOT_PATH { get; set; }
        public static string BASELINE_SCREENSHOT_PATH { get; set; }


        // Reports hiện ra trong bin thay vì folder con của proj??
        public static void InitReportDirection()
        {
            string projectPath = FilePaths.GetCurrentDirectoryPath();
            REPORT_ROOT = projectPath + "\\Reports";
            REPORT_FOLDER_PATH = REPORT_ROOT + "\\Latest Reports";
            REPORT_FILE_PATH = REPORT_FOLDER_PATH + "\\report.html";
            SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\Screenshot";
            // Future lessons
            ACTUAL_SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\Actual";
            DIFFERENCE_SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\Difference";
            BASELINE_SCREENSHOT_PATH = FilePaths.GetCurrentDirectoryPath() + "\\Resource\\Baseline";

            FilePaths.CreateIfNotExists(REPORT_ROOT);
            checkExistReportAndRename(REPORT_FOLDER_PATH); // Check if latest report exists
            FilePaths.CreateIfNotExists(REPORT_FOLDER_PATH);
            FilePaths.CreateIfNotExists(SCREENSHOT_PATH);
            FilePaths.CreateIfNotExists(ACTUAL_SCREENSHOT_PATH);
            FilePaths.CreateIfNotExists(DIFFERENCE_SCREENSHOT_PATH);
            FilePaths.CreateIfNotExists(BASELINE_SCREENSHOT_PATH);



        }
        // Change name of last report folder and create latest report
        private static void checkExistReportAndRename(string reportFolder)
        {
            if (Directory.Exists(reportFolder))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(reportFolder);
                var newPath = REPORT_ROOT + "\\Report_" + dirInfo.CreationTime.
                    ToString().Replace(":", ".").Replace("/", "-");
                Directory.Move(reportFolder, newPath);

            }
        }
    }
}
