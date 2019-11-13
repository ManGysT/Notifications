using Core.Interfaces;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = NotificationServiceFactory.Create();
            var notificationSendOptions = new NotificationSendOptions(NotificationSendMethod.Email)
            {
                NotificationName = Notification.NotificationName.DealCloseRequest,
                RequiresAction = true,
                Payload = new
                {
                    DealID = 111,
                    DealName = "Deal #1",
                    DealProfileUrl = "https://dev.dealius.com/deals/111/",
                },
            };

            var recipients = new List<NotificationRecipient>
            {
                new NotificationRecipient
                {
                    UserID = null,
                    Email = "igortomilov@gmail.com",
                    FirstName = "Igor",
                    LastName = "Tomilov",
                    FirstNameLastName = "Igor Tomilov",
                    FirstNameLastNameShort = "Igor T.",
                    NotificationsSettingsJson = null,
                }
            };

            service.Send(notificationSendOptions, recipients);

            Console.ReadKey();
        }
    }
}