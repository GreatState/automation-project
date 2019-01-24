using AutomationProject.Hybrid.HybridBaseClasses;
using AutomationProject.UITests.BaseClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationProject.Hybrid.Helpers
{
    public class HybridNavigationHelper : HybridBase
    {
        public HybridNavigationHelper(IWebDriver driver)
        {
        }

        public void NavigateToUrl(string path)
        {
            Driver.Navigate().GoToUrl(BaseUrl + path);
            Log.Info("Navigated to: " + BaseUrl + path);
        }

        public static void SwitchFrame(IWebElement element)
        {
            Driver.SwitchTo().Frame(element);
            Log.Info("Switched to frame: " + element);
        }

        public static void SwitchToDefaultFrame()
        {
            Driver.SwitchTo().DefaultContent();
            Log.Info("Switched to default frame");
        }

        public static void ClickElement(IWebElement element)
        {
            element.Click();
            Log.Info("Clicked element: " + element);
        }

        public static void MouseOverElement(IWebElement element)
        {
            var action = new Actions(Driver);
            action.MoveToElement(element);
            Log.Info("Mouse over element: " + element);
        }
    }

}
