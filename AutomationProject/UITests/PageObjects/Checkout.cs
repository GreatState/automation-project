using AutomationProject.UITests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AutomationProject.UITests.PageObjects
{
    internal class Checkout : Page
    {
        private readonly IWebDriver _driver;

        public Checkout(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region PageObjects for Checkout

        private IWebElement ProceedToCheckoutButton => _driver.FindElement(By.LinkText("Proceed to checkout"));
        private IWebElement EmailField => _driver.FindElement(By.Id("email_create"));
        private IWebElement CreateAccountButton => _driver.FindElement(By.Id("SubmitCreate"));
        private IWebElement TitleRadioMr => _driver.FindElement(By.Id("id_gender1"));
        private IWebElement FirstNameField => _driver.FindElement(By.Id("customer_firstname"));
        private IWebElement LastNameField => _driver.FindElement(By.Id("customer_lastname"));
        private IWebElement PasswordField => _driver.FindElement(By.Id("passwd"));
        private IWebElement DaySelect => _driver.FindElement(By.Id("days"));
        private IWebElement MonthSelect => _driver.FindElement(By.Id("months"));
        private IWebElement YearSelect => _driver.FindElement(By.Id("years"));
        private IWebElement NewsletterCheckBox => _driver.FindElement(By.Id("newsletter"));
        private IWebElement SpecialOffersCheckBox => _driver.FindElement(By.Id("optin"));
        private IWebElement CompanyField => _driver.FindElement(By.Id("company"));
        private IWebElement Address1Field => _driver.FindElement(By.Id("address1"));
        private IWebElement Address2Field => _driver.FindElement(By.Id("address2"));
        private IWebElement CityField => _driver.FindElement(By.Id("city"));
        private IWebElement StateSelect => _driver.FindElement(By.Id("id_state"));
        private IWebElement ZipPostcodeField => _driver.FindElement(By.Id("postcode"));
        private IWebElement CountrySelect => _driver.FindElement(By.Id("id_country"));
        private IWebElement AdditionalInfoTextArea => _driver.FindElement(By.Id("other"));
        private IWebElement HomePhoneField => _driver.FindElement(By.Id("phone"));
        private IWebElement MobilePhoneField => _driver.FindElement(By.Id("phone_mobile"));
        private IWebElement AddressAlias => _driver.FindElement(By.Id("alias"));
        private IWebElement RegisterButton => _driver.FindElement(By.Id("submitAccount"));
        private IWebElement CommentField => _driver.FindElement(By.Name("message"));
        private IWebElement ConfirmAddressButton => _driver.FindElement(By.Name("processAddress")); 
        private IWebElement AgreeToTermsCheckBox => _driver.FindElement(By.Id("cgv"));
        private IWebElement ShippingProceedButton => _driver.FindElement(By.Name("processCarrier"));
        private IWebElement BankWireLink => _driver.FindElement(By.XPath("//a[@title='Pay by bank wire']"));
        private IWebElement ConfirmOrderButton => _driver.FindElement(By.XPath("//button[@type='submit' and span='I confirm my order']"));
        private IWebElement CheckoutPageHeading => _driver.FindElement(By.ClassName("page-heading"));

        #endregion

        #region Methods for Checkout

        public void ProceedToCheckout()
        {
            NavigationHelper.SwitchToDefaultFrame();
            NavigationHelper.ClickElement(ProceedToCheckoutButton);
        }

        public void EnterEmailAddress()
        {
            // Generate valid unique email
            var emailAddress = GeneralHelper.GenerateUniqueEmail();
            // Enter email and proceed
            FormHelper.EnterText(EmailField, emailAddress);
            NavigationHelper.ClickElement(CreateAccountButton);
        }

        public void EnterPersonalInfo()
        {
            // Enters personal info and proceed
            FormHelper.ClickRadio(TitleRadioMr);
            FormHelper.EnterText(FirstNameField, "FirstNameValue");
            FormHelper.EnterText(LastNameField, "LastNameValue");
            FormHelper.EnterText(PasswordField, "AutomationPassword1234!");
            FormHelper.SelectValue(DaySelect, "22");
            FormHelper.SelectValue(MonthSelect, "12");
            FormHelper.SelectValue(YearSelect, "1980");
            FormHelper.ClickCheckbox(NewsletterCheckBox);
            FormHelper.ClickCheckbox(SpecialOffersCheckBox);
            FormHelper.EnterText(CompanyField, "CompanyFieldValue");
            FormHelper.EnterText(Address1Field, "Address Line 1 Value");
            FormHelper.EnterText(Address2Field, "Address Line 2 Value");
            FormHelper.EnterText(CityField, "CityValue");
            FormHelper.SelectValue(StateSelect, "32");
            FormHelper.EnterText(ZipPostcodeField, "10304");
            FormHelper.SelectValue(CountrySelect, "21");
            FormHelper.EnterText(AdditionalInfoTextArea, "Additional information value"); // could add additional textarea helper for additional logging info
            FormHelper.EnterText(HomePhoneField, "1111111111");
            FormHelper.EnterText(MobilePhoneField, "222222222");
            FormHelper.EnterText(AddressAlias, "Address alias value");
            NavigationHelper.ClickElement(RegisterButton);
        }

        public void AddComment()
        {
            // Add message
            FormHelper.EnterText(CommentField, "Message value");
            NavigationHelper.ClickElement(ConfirmAddressButton);
        }

        public void AgreeToTerms()
        {
            // Agree to terms
            FormHelper.ClickCheckbox(AgreeToTermsCheckBox);
            NavigationHelper.ClickElement(ShippingProceedButton);
        }

        public void PayByBankWire()
        {
            // Click to pay by wire
            NavigationHelper.ClickElement(BankWireLink);
        }

        public void ConfirmOrder()
        {
            // Click confirm order button
            NavigationHelper.ClickElement(ConfirmOrderButton);
        }

        public void VerifyOrderConfirmation()
        {
            // Check page heading says 'ORDER CONFIRMATION'
            var pageHeadingText = CheckoutPageHeading.Text;
            Assert.IsTrue(pageHeadingText.Equals("ORDER CONFIRMATION"));
        }

        #endregion
    }
}
