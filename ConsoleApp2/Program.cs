using Core.Services;
using Dealius.Notifications;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var notification = new DealCloseRequestNotification
            {
                DealID = 111,
                DealName = "Deal #1",
                DealProfileUrl = "https://dealius.loc/deals/111/"
            };
            var recipients = new List<NotificationRecipient>
            {
                new NotificationRecipient
                {
                    Email = "igortomilov@gmail.com",
                    FirstNameLastName = "Igor Tomilov",
                    UserID = 111,
                    UserNotificationSettingsJson = null,
                }
            };

            var service = new NotificationsServiceFactory().Create();

            Console.ReadKey();
        }
    }
}