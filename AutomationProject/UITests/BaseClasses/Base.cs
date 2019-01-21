using System;
using System.Configuration;
using System.IO;
using AutomationProject.GeneralHelpers;
using AutomationProject.UITests.Helpers;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationProject.UITests.BaseClasses
{
    [TestClass]
    public class Base
    {
        public static IWebDriver Driver;

        public readonly string BaseUrl = ConfigurationManager.AppSettings["baseUrl"];

        // For additional logging with Log4Net
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected Base()
        {
        }

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void InitialiseBrowser()
        {
            // Initialises browser and sets Chrome options
            var options = new ChromeOptions();

            // Uncomment below for desktop
            options.AddArgument("--window-size=1280,3000");

            // Uncomment below for mobile
            // options.EnableMobileEmulation("Nexus 5");

            options.AddArgument("--headless");
            Driver = new ChromeDriver(options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            Log.Info("Browser initialised with options: " + options);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ScreenshotOnFailure();
            Driver.Quit();
            Log.Info("Test clean up complete");
        }

        public void ScreenshotOnFailure()
        {
            var date = GeneralHelper.GetTimeStamp(DateTime.Now, "yyyyMMdd");
            var time = GeneralHelper.GetTimeStamp(DateTime.Now, "HHmmss");
            var resultsDir = TestContext.TestResultsDirectory;
            var path = resultsDir + @"\Screenshots\Exceptions\" + date + "-" + time + @"\";
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Failed) return;
            Log.Fatal("TEST FAILED");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var ss = ((ITakesScreenshot)Driver).GetScreenshot();
            var ssFilename = path + @"\" + TestContext.TestName + "_" + TestContext.CurrentTestOutcome.ToString().ToUpper() + ".png";
            ss.SaveAsFile(ssFilename, ScreenshotImageFormat.Png);
            TestContext.AddResultFile(ssFilename);
            Log.Info("Screenshot saved");
        }
    }

}
