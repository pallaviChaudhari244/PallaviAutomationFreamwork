using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pallavi_AutomationFreamwork
{
    [TestFixture]
    public class ExtentReportClass
    {
        public ExtentReports extent;
        public ExtentTest extentTest;

        [OneTimeSetUp]
        public void Report()
        {
            //Get Project Location
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string prjPath = new Uri(actualPath).LocalPath;

            string reportPath = prjPath + "Reports\\MyReport.html";
            var htmlReport = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();

            //Attach Report to Reporter
            extent.AttachReporter(htmlReport);

            extent.AddSystemInfo("Host Name", "PallaviVethekar");
            extent.AddSystemInfo("Environment", "Testing");
            extent.AddSystemInfo("userName", "PallaviVethekar");
        }

    }
}