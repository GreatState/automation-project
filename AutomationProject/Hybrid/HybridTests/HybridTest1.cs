using System.Linq;
using System.Net;
using AutomationProject.Hybrid.HybridBaseClasses;
using AutomationProject.Hybrid.PageObjects;
using AutomationProject.Rest.RestResponseContainers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationProject.Hybrid.Helpers;
using Cookie = OpenQA.Selenium.Cookie;

namespace AutomationProject.Hybrid.HybridTests
{
    [TestClass]
    public class HybridTest1 : HybridBase
    {
        //[TestMethod]
        //public void AddToBasketVerifyPriceInUi()
        //{
        //    var navigationHelper = new HybridNavigationHelper(Driver);
        //    var basket = new HybridBasket(Client);
        //    //var basket = new Basket(Driver);
        //    //var deserializeJson = new DeserializeJson();
        //    // Initial request to set cookies
        //    //InitialRequest();
        //    // Specify product details to add to basket
        //    navigationHelper.NavigateToUrl("/index.php");

        //    Driver.Manage().Cookies.DeleteAllCookies();
        //    Driver.Manage().Cookies.AddCookie(new Cookie(Cookie.Name, Cookie.Value, Cookie.Path));

        //    const int idProduct = 1;
        //    const int qty = 2;
        //    const int ipa = 4;
        //    // Send request and get response
        //    var response = basket.AddToBasket(idProduct, qty, ipa);
        //    // Deserialize JSON response
        //    RootObject deserializedResponse = (RootObject)DeserializeJson(response);
        //    navigationHelper.NavigateToUrl("/index.php?controller=order");

        //    Driver.Navigate().Refresh();
        //    //basket.VerifyProductInBasket();
        //}


        [TestMethod]
        public void AddToBasketTest2()
        {
            var navigationHelper = new HybridNavigationHelper(Driver);
            var basket = new HybridBasket(Client);

            // Initial webdriver navigation to homepage to get cookies etc.
            navigationHelper.NavigateToUrl("/index.php");

            // Get static token
            var staticToken = GetStaticTokenFromWebdriverSource(Driver);

            // get webdriver cookies container
            var allCookies = Driver.Manage().Cookies.AllCookies;

            // create restsharp cookies container
            var cookieJar = new CookieContainer();

            // add first webdriver cookie to restsharp cookie container
            var cookie = allCookies.FirstOrDefault();
            if (cookie != null)
                cookieJar.Add(new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
            Client.CookieContainer = cookieJar;

            // parameters for addToBasket post request
            const int idProduct = 1;
            const int qty = 2;
            const int ipa = 4;

            // Send request and get response
            var response = basket.AddToBasket(idProduct, qty, ipa, staticToken);
            Log.Info(response.Content);

            // Deserialize JSON response
            //RootObject deserializedResponse = (RootObject)DeserializeJson(response);
            navigationHelper.NavigateToUrl("/index.php?controller=order"); // at this point we should see items in basket, but we don't yet

            //basket.VerifyProductInBasket();
        }
    }
}
