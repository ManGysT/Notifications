using Core.Interfaces.Notifications;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = NotificationServiceFactory.Create();
            var notificationSendOptions = new NotificationSendOptions(NotificationSendMethod.All)
            {
                Notification = new Notification.Notification
                {
                    NotificationName = Notification.NotificationName.DealCloseRequest,
                    RequiresAction = true,
                    Payload = new
                    {
                        DealID = 111,
                        DealName = "Deal #1",
                        DealProfileUrl = "https://dev.dealius.com/deals/111/",
                    },
                }
            };

            var recipients = new List<NotificationRecipient>
            {
                new NotificationRecipient
                {
                    Email = "igortomilov@gmail.com",
                    NotificationsSettingsJson = null,
                }
            };

            service.Send(notificationSendOptions, recipients);

            //Console.ReadKey();
        }
    }
}