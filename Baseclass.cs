using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pallavi_AutomationFreamwork
{
    public class Baseclass
    {
        public string TakeScreenshot()
        {
            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            string path = path1 + "Screenshot\\" + ".png";
            Screenshot screenshot = ((ITakesScreenshot)DriverContext.driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }
    }
}
