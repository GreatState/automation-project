using System;
using AutomationProject.UITests.BaseClasses;
using OpenQA.Selenium;

namespace AutomationProject.UITests.Helpers
{
    public class UIHelper : Base
    {
        public static bool IsElementPresent(IWebElement element)
        {
            //if (element.Displayed.Equals(true))
            //{
            //    Log.Info("Element present: " + element);
            //    return element.Displayed.Equals(true);
            //}
            //Log.Error("Element not present: " + element);
            //return element.Displayed.Equals(false);
            try
            {
                Log.Info("Checking for the element: " + element);
                return element.Displayed.Equals(true);
            }
            catch (Exception e)
            {
                Log.Error("Could not locate element: " + element + "\nException: " + e);
                return false;
            }
        }

        public static bool ViewportWidthLessThan(int width)
        {
            // returns browser size
            var viewportWidth = Driver.Manage().Window.Size.Width;
            Log.Info("Viewport width: " + viewportWidth);
            return width > viewportWidth;
        }
    }
}

