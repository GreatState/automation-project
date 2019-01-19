using System;
using OpenQA.Selenium;
using AutomationProject.BaseClasses;

namespace AutomationProject.Helpers
{
    public class GeneralHelper : Base
    {
        public static string GetTimeStamp(DateTime value, string format)
        {
            // Gets timestamp in defined format
            var timeStamp = value.ToString(format);
            Log.Info("Timestamp generated: " + timeStamp);
            return timeStamp;
        }

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

        public static string GenerateUniqueEmail()
        {
            // Appends timestamp to first part of email to create unique address
            var timestamp = GetTimeStamp(DateTime.Now, "yyyyMMddHHmmssfff");
            var emailAddress = "johnbuttone3+" + timestamp + "@gmail.com";
            Log.Info("Email address generated: " + emailAddress);
            return emailAddress;
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

