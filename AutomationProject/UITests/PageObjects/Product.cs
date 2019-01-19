using AutomationProject.UITests.Helpers;
using OpenQA.Selenium;

namespace AutomationProject.UITests.PageObjects
{
    internal class Product
    {
        private readonly IWebDriver _driver;

        public Product(IWebDriver driver)
        {
            _driver = driver;
        }

        #region PageObjects for Product

        private IWebElement ProductModal => _driver.FindElement(By.ClassName("fancybox-iframe"));
        private IWebElement SizeSelect => _driver.FindElement(By.Id("group_1"));
        private IWebElement ColourBlueElement => _driver.FindElement(By.Id("color_14"));
        private IWebElement AddToCartButton => _driver.FindElement(By.Name("Submit"));
        private IWebElement ProceedToCheckoutButton => _driver.FindElement(By.XPath("//a[contains(@title,'Proceed to checkout')]"));

        #endregion

        #region Methods for Product

        public void SelectSize(string value)
        {
            NavigationHelper.SwitchFrame(ProductModal);
            FormHelper.SelectValue(SizeSelect, value);
        }

        public void SelectColourBlue()
        {
            NavigationHelper.ClickElement(ColourBlueElement);
        }

        public void AddToCart()
        {
            NavigationHelper.ClickElement(AddToCartButton);
        }

        public void ProceedToCheckout()
        {
            NavigationHelper.ClickElement(ProceedToCheckoutButton);
        }

        #endregion
    }
}
