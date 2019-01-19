using System.Collections.Generic;

namespace AutomationProject.Rest.RestResponseContainers
{
    //created by pasting json response into http://json2csharp.com/
    public class Product
    {
        public int id { get; set; }
        public string link { get; set; }
        public int quantity { get; set; }
        public string image { get; set; }
        public string image_cart { get; set; }
        public string priceByLine { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public double price_float { get; set; }
        public int idCombination { get; set; }
        public int idAddressDelivery { get; set; }
        public bool is_gift { get; set; }
        public bool hasAttributes { get; set; }
        public string attributes { get; set; }
        public bool hasCustomizedDatas { get; set; }
        public List<object> customizedDatas { get; set; }
    }

    public class RootObject
    {
        public List<Product> products { get; set; }
        public List<object> discounts { get; set; }
        public string shippingCost { get; set; }
        public int shippingCostFloat { get; set; }
        public string wrappingCost { get; set; }
        public int nbTotalProducts { get; set; }
        public string total { get; set; }
        public string productTotal { get; set; }
        public string freeShipping { get; set; }
        public int freeShippingFloat { get; set; }
        public bool hasError { get; set; }
        public string crossSelling { get; set; }
    }
}
