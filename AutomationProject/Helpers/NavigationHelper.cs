using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using AutomationProject.BaseClasses;

namespace AutomationProject.Helpers
{
    public class NavigationHelper : Base
    {
        public NavigationHelper(IWebDriver driver)
        {
        }

        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
            Log.Info("Navigated to: " + url);
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
