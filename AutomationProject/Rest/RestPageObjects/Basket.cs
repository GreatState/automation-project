using System.Dynamic;
using AutomationProject.Rest.RestBaseClasses;
using RestSharp;

namespace AutomationProject.Rest.RestPageObjects
{
    internal class Basket : RestBase
    {
        private readonly IRestClient _restClient;

        public Basket(IRestClient restClient)
        {
            _restClient = restClient;
        }

        #region PageObjects for Product



        #endregion

        #region Methods for ApiBase

        public static IRestResponse AddToBasket(int idProduct, int qty, int ipa)
        {
            // Defines request URL
            var request = new RestRequest("/index.php?rand=1547644853512", Method.POST);

            // Constants for body requerst
            const string controller = "cart";
            const string add = "1";
            const string ajax = "true";

            // Construct body string
            var bodyString = $"controller={controller}&add={add}&ajax={ajax}&qty={qty}&id_product={idProduct}&token={StaticToken}&ipa={ipa}";

            // Add request headers
            AddRequestHeaders(request);

            // Add request parameters
            request.AddParameter("controller", controller);
            request.AddParameter("add", add);
            request.AddParameter("ajax", ajax);
            request.AddParameter("token", StaticToken);
            request.AddParameter("ipa", ipa);
            request.AddParameter("id_product", idProduct);
            request.AddParameter("qty", qty);
            request.AddParameter("RequestBody", bodyString);

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
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("Referrer", "http://automationpractice.com/index.php?id_product=1&controller=product&content_only=1");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Accept-Language", "en-US,en;q=0.9");
            return request;
        }

        #endregion
    }
}
