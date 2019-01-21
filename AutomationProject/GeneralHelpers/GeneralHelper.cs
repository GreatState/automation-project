using System;
using System.Configuration;
using AutomationProject.UITests.BaseClasses;

namespace AutomationProject.GeneralHelpers
{
    public class GeneralHelper : Base
    {
        private static readonly string FirstPartEmail = ConfigurationManager.AppSettings["firstPartEmail"];

        public static string GetTimeStamp(DateTime value, string format)
        {
            // Gets timestamp in defined format
            var timeStamp = value.ToString(format);
            Log.Info("Timestamp generated: " + timeStamp);
            return timeStamp;
        }

        public static string GenerateUniqueEmail()
        {
            // Appends timestamp to first part of email to create unique address
            var timestamp = GetTimeStamp(DateTime.Now, "yyyyMMddHHmmssfff");
            var emailAddress = FirstPartEmail + timestamp + "@gmail.com";
            Log.Info("Email address generated: " + emailAddress);
            return emailAddress;
        }
    }
}