using Core.Common.Interfaces;
using Core.UserNotifications.Models;
using Core.UserNotifications.Models.Notifications;
using Infrastructure.UserNotifications;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ISettingsManager settings = new DefaultSettingsManager();

            SendNotification(settings);

            Console.WriteLine();
            Console.WriteLine("All notifications sent!");
            Console.ReadLine();
        }

        static void SendNotification(ISettingsManager settings)
        {
            var notification = GetNotification();
            var recipients = GetRecipients();

            var service = UserNotificationServiceFactory.Create(settings);
            var task = service.Send(notification, recipients)
                ;
            task.Wait();
        }

        static UserNotification GetNotification()
        {
            return new MyNotification
            {
                UserName = "ManGysT",
                UserPassword = "473267",
            };
        }

        static IEnumerable<UserNotificationRecipient> GetRecipients()
        {
            var recipients = new UserNotificationRecipient[1];

            for (int i = 0; i < recipients.Length; i++)
            {
                recipients[i] = new UserNotificationRecipient
                {
                    Email = i % 2 == 1 || true ? $"igortomilov+{i}@gmail.com" : null,
                    EmailName = $"Igor Tomilov {i}",
                    EmailFriendlyName = $"Igor {i}"
                };
            }

            return recipients;
        }
    }
}