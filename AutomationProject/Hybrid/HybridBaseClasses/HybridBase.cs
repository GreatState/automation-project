using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.ModelBinding;
using AutomationProject.GeneralHelpers;
using AutomationProject.Rest.RestResponseContainers;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using RestSharp.Serialization.Json;
using Cookie = OpenQA.Selenium.Cookie;

namespace AutomationProject.Hybrid.HybridBaseClasses
{
    [TestClass]
    public class HybridBase
    {
        public static IWebDriver Driver;

        public static RestClient Client;
        //public TestContext TestContext { get; set; }
        public static string StaticToken;
        // For additional logging with Log4Net
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RestResponseCookie Cookie;

        public readonly string BaseUrl = ConfigurationManager.AppSettings["baseUrl"];

        protected HybridBase()
        {
        }

        public TestContext TestContext { get; set; }

        public static string Rand;

        [TestInitialize]
        public void InitialiseBrowser()
        {
            // Initialise RestClient
            Client = new RestClient(BaseUrl);

            //create random number for string
            Rand = RandomString(13);
            Log.Info(Rand);
            // Initial homepage request

            // Set Chrome options
            var options = new ChromeOptions();

            // Uncomment below for desktop
            options.AddArgument("--window-size=1280,3000");

            // Uncomment below for mobile
            // options.EnableMobileEmulation("Nexus 5");

            //options.AddArgument("--headless");

            // Set cookies
            //Cookie = SetCookies(responseHomePage);

            Driver = new ChromeDriver(options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            //var allCookies = Driver.Manage().Cookies.AllCookies;


            Log.Info("Browser initialised with options: " + options);

            //var cookie = cookieJar(new Uri(BaseUrl));
            
            //Driver.Manage().Cookies.AddCookie(cookie);
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

        //public void InitialRequest()
        //{
        //    // Initial homepage request
        //    var requestHomePage = new RestRequest("/index.php", Method.GET);
        //    var responseHomePage = Client.Execute(requestHomePage);

        //    // Set cookies
        //    SetCookies(responseHomePage);
        //    // Get static token
        //    GetStaticToken(responseHomePage);
        //}

        private static RestResponseCookie SetCookies(IRestResponse response)
        {
            var cookieJar = new CookieContainer();

            // If responds with 200 then set cookie
            RestResponseCookie cookie = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                cookie = response.Cookies.FirstOrDefault();
                if (cookie != null)
                {
                    // add cookie to .NET cookie container
                    cookieJar.Add(new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
                }
            }
            Client.CookieContainer = cookieJar;
            return cookie;
        }

        //private static void GetStaticTokenFromRestResponse(IRestResponse response)
        //{
        //     Get token
        //    var match = Regex.Match(response.Content, @"static_token \= \'([A-Za-z0-9\-]+)\'\;", RegexOptions.IgnoreCase);
        //    StaticToken = match.Groups[1].Value;
        //    Console.WriteLine(StaticToken);
        //}

        public static string GetStaticTokenFromWebdriverSource(IWebDriver driver)
        {
            // Get token
            var match = Regex.Match(driver.PageSource, @"static_token \= \'([A-Za-z0-9\-]+)\'\;", RegexOptions.IgnoreCase);
            StaticToken = match.Groups[1].Value;
            Console.WriteLine(StaticToken);
            return StaticToken;
        }

        public object DeserializeJson(IRestResponse response)
        {
            var deserializer = new JsonDeserializer();
            Log.Info(response.Content);
            var obj = deserializer.Deserialize<RootObject>(response);
            return obj;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}
