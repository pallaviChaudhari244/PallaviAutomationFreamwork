using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pallavi_AutomationFreamwork
{
    public class AutomationFramwork
    {

        //for extent Report 
        public ExtentReports extent = new ExtentReports();

        public static string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;  //for assembly

        public static string actualPath = path.Substring(0, path.LastIndexOf("bin"));
        public static string prjPath = new Uri(actualPath).LocalPath;
        public static string reportPath = prjPath + "Reports\\MyReport.html";
        ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(reportPath);

        //Obj creation
        public ExtentTest extentTest;
        //Obj base class
        Baseclass baseClass = new Baseclass();

        [SetUp]
        public void Initialize()
        {
            System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", "C:/Users/p10470679/Downloads/chromedriver_win32/chromedriver.exe");
            DriverContext.driver = new ChromeDriver();            //navigate  to URL
            DriverContext.driver.Navigate().GoToUrl("http://automationpractice.com/");
            extent.AddSystemInfo("Environment", "Testing");
            extent.AddSystemInfo("User Name", "Pallavi Chaudhari");
            extent.AttachReporter(htmlReport);
            DriverContext.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [Test]
        public void _1MyTestOne()
        {
            extentTest = extent.CreateTest("MyTestOne", "Add items to Cart and purchase them");
            CommanPages compage = new CommanPages();
            compage.MyLoginApplication("pallavichaudhari244@gmail.com", "FujitsuTest");
            //Added first Item
            compage.Add_Shirt();
            extentTest.Log(Status.Pass, "Tshirt added to cart");
            //Added sec order
            compage.AddSecondItem();
            compage.IVerify_CartItems();
            //Verify or confirm ordr
            compage.IConfirmOrder();
            extentTest.Log(Status.Pass, "Confirmed order & Payment Done");

        }

        [Test]
        public void _2MyTestSec()
        {
            extentTest = extent.CreateTest("MySecTest", "Add a message for order & verify the same");
            CommanPages ComPage = new CommanPages();

            ComPage.MyLoginApplication("pallavichaudhari244@gmail.com", "FujitsuTest");
            ComPage.NavigateToOrdersAddMessage();
            ComPage.verifySuccessAlertAndMessage();
            extentTest.Log(Status.Pass, "Verified message under the Message Tab");
            ComPage.Logout();
        }

        [Test]
        public void _3TestThree()
        {
            extentTest = extent.CreateTest("TestThree", "Verify Product Colour is Blue");
            CommanPages ComPage = new CommanPages();

            ComPage.MyLoginApplication("pallavichaudhari244@gmail.com", "FujitsuTest");
            ComPage.GoToOrders();

            try
            {

                DriverContext.driver.FindElement(By.XPath("//tr[@class='item']//td[2]//label[contains(text(),'Chiffon')][contains(text(),'Blue')]")).Displayed.Equals(true);
                extentTest.Log(Status.Pass, "Product Colour is Blue");
            }
            catch (Exception ex)
            {
                string path = baseClass.TakeScreenshot();

                extentTest.Log(Status.Fail, "Product Colour should have been Blue");
                extentTest.AddScreenCaptureFromPath(path);

            }
            ComPage.Logout();

        }

        [TearDown]
        //exit from all browser
        public void closeBrowser()
        {
            extent.Flush();
            DriverContext.driver.Quit();
        }

    }
}
