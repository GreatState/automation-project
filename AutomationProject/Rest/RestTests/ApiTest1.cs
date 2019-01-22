using AutomationProject.Rest.RestBaseClasses;
using AutomationProject.Rest.RestPageObjects;
using AutomationProject.Rest.RestResponseContainers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace AutomationProject.Rest.RestTests
{
    [TestClass]
    public class ApiTests : RestBase
    {
        [TestMethod]
        public void AddToBasketVerifyDetails()
        {
            // Specify product details to add to basket
            const int idProduct = 1;
            const int qty = 2;
            const int ipa = 4;
            // Send request and get response
            var response = Basket.AddToBasket(idProduct, qty, ipa);
            // Deserialize JSON response
            RootObject deserializedResponse = (RootObject)DeserializeJson(response);
            // Verify response code
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            // Verify product ID in response
            Assert.AreEqual(idProduct, deserializedResponse.products[0].id);
            // Verify quantity in response
            Assert.AreEqual(qty, deserializedResponse.products[0].quantity);
        }
    }
}
