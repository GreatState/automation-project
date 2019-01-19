using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using AutomationProject.Rest.RestBaseClasses;
using AutomationProject.Rest.RestPageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AutomationProject.Rest.RestTests
{
    [TestClass]
    public class ApiTests : ApiBase
    {
        [TestMethod]
        public void AddToBasketStatus()
        {
            var apiObjects = new ApiObjects(Client);
            var response = apiObjects.AddToBasket();
            // assert status code
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void AddToBasketVerifyIsJson()
        {
            var apiObjects = new ApiObjects(Client);
            var response = apiObjects.AddToBasket();
            // assert status code
            //var deserializer = new JsonDeserializer();
            Log.Info(response);

            // parse the json response so that we can get at the key/value pairs
            //JToken token = JObject.Parse(response);
            //JObject jsonObject = JObject.Parse(response);
            //var jsonObject = deserializer.Deserialize<Dictionary<string, string>>(response);
            //Log.Info(jsonObject);



            //if (jsonObject.ContainsKey("freeShipping"))
            //{
            //    Console.WriteLine("\nFOUND");
            //}
            //deserializer.Deserialize<List<InventoryItem>>(response);

            //Assert.AreEqual("json", response.ContentType);
        }

        [TestMethod]
        public void AddToBasketOriginal()
        {
            var client = new RestClient("http://automationpractice.com/");
            // Initial homepage request to set cookies and get tokens
            var requestHomePage = new RestRequest("/index.php", Method.GET);
            var responseHomePage = client.Execute(requestHomePage);

            //Uri uri = new Uri("http://automationpractice.com/");

            var cookieJar = new CookieContainer();

            if (responseHomePage.StatusCode == HttpStatusCode.OK)
            {
                var cookie = responseHomePage.Cookies.FirstOrDefault();
                if (cookie != null) cookieJar.Add(new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
            }

            client.CookieContainer = cookieJar;

            // gets static_key from response
            var match = Regex.Match(responseHomePage.Content, @"static_token \= \'([A-Za-z0-9\-]+)\'\;", RegexOptions.IgnoreCase);
            var staticToken = match.Groups[1].Value;
            Console.WriteLine(staticToken);

            var request = new RestRequest("/index.php?rand=1547644853512", Method.POST);

            const string controller = "cart";
            const string add = "1";
            const string ajax = "true";
            const string qty = "1";
            const string idProduct = "1";
            const string ipa = "4";

            request.AddParameter("controller", "cart");
            request.AddParameter("add", "1");
            request.AddParameter("ajax", "true");
            request.AddParameter("token", staticToken);
            request.AddParameter("ipa", "4");
            request.AddParameter("id_product", "1");
            request.AddParameter("qty", "1");
            request.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
            request.AddHeader("Content-Length", "95");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Origin", "http://automationpractice.com");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("Referrer", "http://automationpractice.com/index.php?id_product=1&controller=product&content_only=1");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Accept-Language", "en-US,en;q=0.9");


            var bodyString = $"controller={controller}&add={add}&ajax={ajax}&qty={qty}&id_product={idProduct}&token={staticToken}&ipa={ipa}";
            Console.WriteLine(bodyString);
            request.AddParameter("RequestBody", bodyString);

            // act
            var response = client.Execute(request);
            //Console.WriteLine(request.xm);
            Console.Write(response.Content);

            // assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
