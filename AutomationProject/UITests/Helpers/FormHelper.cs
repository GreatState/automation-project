using AutomationProject.UITests.BaseClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationProject.UITests.Helpers
{
    public class FormHelper : Base
    {
        // For additional logging with Log4Net

        public static void EnterText(IWebElement element, string text)
        {
            //add logging
            element.Clear();
            element.SendKeys(text);
            Log.Info(text + " entered in " + element + " text field");
        }

        public static void SelectValue(IWebElement element, string value)
        {
            //add logging
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
            Log.Info(value + " selected in " + element + " select box");
        }

        public static void ClickRadio(IWebElement element)
        {
            //add logging
            element.Click();
            Log.Info("Radio button clicked: " + element);
        }

        public static void ClickCheckbox(IWebElement element)
        {
            //add logging
            element.Click();
            Log.Info("Checkbox clicked: " + element);
        }

    }

}
