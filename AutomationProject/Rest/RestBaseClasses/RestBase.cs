using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AutomationProject.Rest.RestBaseClasses
{
    [TestClass]
    public class RestBase
    {
        public static RestClient Client;
        public TestContext TestContext { get; set; }
        public string StaticToken;
        // For additional logging with Log4Net
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected RestBase()
        {
        }

        [TestInitialize]
        public void InitialRequest()
        {
            // Initialise RestClient
            Client = new RestClient("http://automationpractice.com/");

            // Initial homepage request
            RestRequest requestHomePage = new RestRequest("/index.php", Method.GET);
            IRestResponse ResponseHomePage = Client.Execute(requestHomePage);

            // Set cookies
            SetCookies(ResponseHomePage);
            // Get static token
            GetStaticToken(ResponseHomePage);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //ScreenshotOnFailure();
            //Driver.Quit();
            //Log.Info("Test clean up complete");
        }

        private void SetCookies(IRestResponse response)
        {
            CookieContainer cookieJar = new CookieContainer();

            // If responds with 200 then set cookie
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var cookie = response.Cookies.FirstOrDefault();
                cookieJar.Add(new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
            }
            Client.CookieContainer = cookieJar;
        }

        private void GetStaticToken(IRestResponse response)
        {
            // Get token
            Match match = Regex.Match(response.Content, @"static_token \= \'([A-Za-z0-9\-]+)\'\;", RegexOptions.IgnoreCase);
            StaticToken = match.Groups[1].Value;
            Console.WriteLine(StaticToken);
        }
    }
}
