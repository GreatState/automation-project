using AutomationProject.Hybrid.HybridBaseClasses;
using AutomationProject.Rest.RestBaseClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using RestSharp;
using AutomationProject.GeneralHelpers;
using AutomationProject.UITests.Helpers;

namespace AutomationProject.Hybrid.PageObjects
{
    internal class HybridBasket : HybridBase
    {
        private readonly IRestClient _restClient;

        public HybridBasket(IRestClient restClient)
        {
            _restClient = restClient;
        }
        private readonly IWebDriver _driver;

        public HybridBasket(IWebDriver driver)
        {
            _driver = driver;
        }

        #region PageObjects for HybridBasket

        //temp for hybrid test
        private IWebElement Product1Price => _driver.FindElement(By.ClassName("price"));

        #endregion

        #region Methods for HybridBasket

        public IRestResponse HybridAddToBasket(int idProduct, int qty, int ipa, string staticToken)
        {
            // Defines request URL
            var request = new RestRequest("/index.php?rand=1547644853512", Method.POST);

            // Constants for body requerst
            const string controller = "cart";
            const string add = "1";
            const string ajax = "true";

            // Construct body string
            //var bodyString = $"controller={controller}&add={add}&ajax={ajax}&qty={qty}&id_product={idProduct}&token={StaticToken}&ipa={ipa}";

            // Add request headers
            //AddRequestHeaders(request);

            // Add request parameters
            request.AddParameter("controller", controller);
            request.AddParameter("add", add);
            request.AddParameter("ajax", ajax);
            request.AddParameter("qty", qty);
            request.AddParameter("id_product", idProduct);
            request.AddParameter("token", staticToken);
            request.AddParameter("ipa", ipa);


            request.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
            request.AddHeader("Content-Length", "95");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Origin", "http://automationpractice.com");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            // below updated to headless chrome agent
            Client.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) HeadlessChrome/71.0.3578.98 Safari/537.36";
            //request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) HeadlessChrome/71.0.3578.98 Safari/537.36");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("Referrer", "http://automationpractice.com/index.php?id_product=1&controller=product&content_only=1");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Accept-Language", "en-US,en;q=0.9");
            //request.AddParameter("RequestBody", bodyString);

            // Execute, get and return response
            var response = Client.Execute(request);
            return response;
        }

        public static RestRequest AddRequestHeaders(RestRequest request)
        {
            request.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
            request.AddHeader("Content-Length", "95");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Origin", "http://automationpractice.com");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            // below updated to headless chrome agent
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) HeadlessChrome/71.0.3578.98 Safari/537.36");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("Referrer", "http://automationpractice.com/index.php?id_product=1&controller=product&content_only=1");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Accept-Language", "en-US,en;q=0.9");
            return request;
        }

        public void VerifyProductInBasket()
        {
            // Check page heading says 'ORDER CONFIRMATION'
            var pageHeadingText = Product1Price.Text;
            Assert.IsTrue(pageHeadingText.Equals("ORDER CONFIRMATION"));
        }

        #endregion
    }
}
