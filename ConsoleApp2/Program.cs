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
            var recipients = GetRecipients();

            var service = new NotificationsServiceFactory().Create();
            service.Send(notification, recipients).Wait();

            Console.WriteLine();
            Console.WriteLine("All notifications sent!");
            Console.ReadKey();
        }

        static IEnumerable<NotificationRecipient> GetRecipients()
        {
            var recipients = new NotificationRecipient[100];

            for (int i = 0; i < recipients.Length; i++)
            {
                recipients[i] = new NotificationRecipient
                {
                    Email = i % 2 == 1 ? $"igortomilov+{i + 1}@gmail.com" : null,
                    FirstNameLastName = "Igor Tomilov",
                    DealiusUserID = 111 + i,
                    UserNotificationSettingsJson = null,
                };
            }

            return recipients;
        }
    }
}