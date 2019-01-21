using AutomationProject.UITests.BaseClasses;
using AutomationProject.UITests.Helpers;
using AutomationProject.UITests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationProject.UITests.Tests
{
    [TestClass]
    public class HappyPathTests : Base
    {
        [TestMethod]
        public void HappyPathComplex()
        {
            var navigationHelper = new NavigationHelper(Driver);
            var homePage = new HomePage(Driver);
            var product = new Product(Driver);
            var checkout = new Checkout(Driver);
            var page = new Page(Driver);

            // Navigate to homepage
            navigationHelper.NavigateToUrl("/");
            // Open quick view on first item on homepage
            homePage.ClickQuickView();
            // Select size 'M'
            product.SelectSize("2");
            // Select colour 'Blue'
            product.SelectColourBlue();
            // Add to cart
            product.AddToCart();
            // Proceed to Checkout on modal
            product.ProceedToCheckout();
            // Proceed to checkout on 'Summary' step
            checkout.ProceedToCheckout();
            // Enter email and proceed to create account
            checkout.EnterEmailAddress();
            // Enter personal info and proceed on 'Sign in' step
            checkout.EnterPersonalInfo();
            // Add message and proceed on 'Address' step
            checkout.AddComment();
            // Agree to terms and proceed
            checkout.AgreeToTerms();
            // Click to pay by bank wire
            checkout.PayByBankWire();
            // Click to confirm order
            checkout.ConfirmOrder();
            // Verify order successfully placed
            checkout.VerifyOrderConfirmation();
            // Sign out
            checkout.ClickSignOut();
            // Verify signed out
            page.CheckSignedOut();
        }

        [TestMethod]
        public void HappyPathComplexFail()
        {
            var navigationHelper = new NavigationHelper(Driver);
            var homePage = new HomePage(Driver);
            var product = new Product(Driver);
            var checkout = new Checkout(Driver);
            var page = new Page(Driver);

            // Navigate to homepage
            navigationHelper.NavigateToUrl("/");
            // Open quick view on first item on homepage
            homePage.ClickQuickView();
            // Select size 'M'
            product.SelectSize("2");
            // Select colour 'Blue'
            product.SelectColourBlue();
            // Add to cart
            product.AddToCart();
            // Proceed to Checkout on modal
            product.ProceedToCheckout();
            // Proceed to checkout on 'Summary' step
            checkout.ProceedToCheckout();
            // Enter email and proceed to create account
            checkout.EnterEmailAddress();
            // Enter personal info and proceed on 'Sign in' step
            checkout.EnterPersonalInfo();
            // Add message and proceed on 'Address' step
            checkout.AddComment();
            // Verify signed out - THIS WILL FAIL AT THIS POINT PURPOSEFULLY
            page.CheckSignedOut();
        }

    }
}
