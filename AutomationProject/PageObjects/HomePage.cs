using OpenQA.Selenium;
using AutomationProject.Helpers;

namespace AutomationProject.PageObjects
{
    public class HomePage : Page
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region PageObjects for HomePage

        private IWebElement Product1Container => _driver.FindElement(By.XPath("//a[contains(@title,'Faded Short Sleeve T-shirts')]"));
        private IWebElement Product1QuickViewMobile =>  _driver.FindElement(By.XPath("//a[contains(@href,'product=1') and ((@class='quick-view') or (@class='quick-view-mobile'))]"));

        #endregion

        #region Methods for HomePage

        public void ClickQuickView()
        {
            //var isMobile = GeneralHelper.CheckElementPresent(Product1QuickViewMobile);
            var isMobileOrTablet = GeneralHelper.ViewportWidthLessThan(1200);
            if (isMobileOrTablet)
            {
                NavigationHelper.ClickElement(Product1QuickViewMobile);
            }
            else
            {
                NavigationHelper.MouseOverElement(Product1Container);
                NavigationHelper.ClickElement(Product1Container);
            }
        }

        #endregion
    }
}
