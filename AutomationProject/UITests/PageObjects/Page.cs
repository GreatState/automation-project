using AutomationProject.UITests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AutomationProject.UITests.PageObjects
{
    public class Page
    {
        private readonly IWebDriver _driver;

        public Page(IWebDriver driver)
        {
            _driver = driver;
        }

        #region PageObjects for Page

        private IWebElement SignOutLink => _driver.FindElement(By.ClassName("logout"));
        private IWebElement SignInLink => _driver.FindElement(By.ClassName("login"));

        #endregion

        #region Methods for Page

        public void ClickSignOut()
        {
            NavigationHelper.ClickElement(SignOutLink);
        }

        public void CheckSignedOut()
        {
            // Checks that Sign in button is present
            var loginLinkStatus = GeneralHelper.IsElementPresent(SignInLink);
            Assert.IsTrue(loginLinkStatus);
            // GeneralHelper.CheckElementPresent(SignInLink);
            Assert.IsTrue(GeneralHelper.IsElementPresent(SignInLink));
        }

        #endregion
    }
}
