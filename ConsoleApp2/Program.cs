using Core.Services;
using Core.Services.Notifications;
using Notification;
using Notifications;
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

            var service = NotificationServiceFactory.Create(settings);
            var task = service.Send(notification, recipients)
                ;
            task.Wait();
        }

        static INotification GetNotification()
        {
            return new MyNotification
            {
                UserName = "ManGysT",
                UserPassword = "473267",
            };
        }

        static IEnumerable<IRecipient> GetRecipients()
        {
            var recipients = new IRecipient[1];

            for (int i = 0; i < recipients.Length; i++)
            {
                recipients[i] = new NotificationRecipient
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