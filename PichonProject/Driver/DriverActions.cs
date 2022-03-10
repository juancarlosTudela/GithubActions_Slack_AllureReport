using Allure.Commons;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PichonProject.Driver
{
    public class DriverActions
    {
        public static void TakeTestScreenShot(IWebDriver Idriver)
        {
            Screenshot ss = ((ITakesScreenshot)Idriver).GetScreenshot();
            //string completeFilePath = GetFilePath(".png", fileName);
            string timestamp = DateTime.Now.ToString("_dd_MM_yyyy_HH_mm_ss");
            var filename = TestContext.CurrentContext.Test.MethodName + "_screenshot_" + timestamp + ".png";

            string screenShotDirName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScreenShots");
            Directory.CreateDirectory(screenShotDirName);

            var path = Path.Combine(screenShotDirName, filename);

            ss.SaveAsFile(path, ScreenshotImageFormat.Png);

            TestContext.AddTestAttachment(path);
            AllureLifecycle.Instance.AddAttachment(filename, "image/png", path);
        }

        public static void TakeTestScreenShot(IWebDriver Idriver,string filename)
        {
            Screenshot ss = ((ITakesScreenshot)Idriver).GetScreenshot();
            //string completeFilePath = GetFilePath(".png", fileName);
            string timestamp = DateTime.Now.ToString("_dd_MM_yyyy_HH_mm_ss");
            filename = filename + timestamp + ".png";

            string screenShotDirName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScreenShots");
            Directory.CreateDirectory(screenShotDirName);

            var path = Path.Combine(screenShotDirName, filename);

            ss.SaveAsFile(path, ScreenshotImageFormat.Png);

            TestContext.AddTestAttachment(path);
            AllureLifecycle.Instance.AddAttachment(filename, "image/png", path);
        }
    }
}
