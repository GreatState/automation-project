using AutomationProject.Rest.RestBaseClasses;
using RestSharp;

namespace AutomationProject.Rest.RestPageObjects
{
    internal class RestObjects : RestBase
    {
        private readonly IRestClient _restClient;

        public RestObjects(IRestClient restClient)
        {
            _restClient = restClient;
        }

        #region PageObjects for Product



        #endregion

        #region Methods for ApiBase


        //public IRestResponse HomePageRequest(IRestClient client)
        //{
        //    // Initial homepage request to set cookies and get tokens
        //    RestRequest requestHomePage = new RestRequest("/index.php", Method.GET);
        //    IRestResponse responseHomePage = client.Execute(requestHomePage);

        //    //Uri uri = new Uri("http://automationpractice.com/");

        //    CookieContainer cookieJar = new CookieContainer();

        //    if (responseHomePage.StatusCode == HttpStatusCode.OK)
        //    {
        //        var cookie = responseHomePage.Cookies.FirstOrDefault();
        //        cookieJar.Add(new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
        //    }

        //    client.CookieContainer = cookieJar;
        //    return responseHomePage;
        //}

        //public string GetToken(IRestResponse response)
        //{
        //    Match match = Regex.Match(response.Content, @"static_token \= \'([A-Za-z0-9\-]+)\'\;", RegexOptions.IgnoreCase);
        //    var staticToken = match.Groups[1].Value;
        //    Console.WriteLine(staticToken);
        //    return staticToken;
        //}

        public IRestResponse AddToBasket()
        {
            // add to basket

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
            request.AddParameter("token", StaticToken);
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

            var bodyString = $"controller={controller}&add={add}&ajax={ajax}&qty={qty}&id_product={idProduct}&token={StaticToken}&ipa={ipa}";
            request.AddParameter("RequestBody", bodyString);

            // act
            var response = Client.Execute(request);
            //Console.WriteLine(request.xm);
            //Console.Write(response.Content);
            return response;
        }

        #endregion
    }
}
