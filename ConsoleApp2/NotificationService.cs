using Core.Interfaces;
using Core.Interfaces.Notifications;
using Notification;
using Notification.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationSenderCollection notificationSenders;

        public NotificationService(NotificationSenderCollection notificationSenders)
        {
            this.notificationSenders = notificationSenders;
        }

        public void Send(NotificationSendOptions sendOptions, IEnumerable<NotificationRecipient> recipients)
        {
            var sendMethods = sendOptions.SendMethod.Enumerate();
            if (sendMethods.Length == 0)
            {
                return;
            }

            var sendTasks = new Task[sendMethods.Length];

            foreach (var sendMethod in sendMethods)
            {
                INotificationSender sender;
                if (!this.notificationSenders.TryGetValue(sendMethod, out sender))
                {
                    throw new NotImplementedNotificationSender(sendMethod);
                }

                var targetRecipients = recipients.Where(x => true); // filter out recipients with turned off send method or nitification name
                var notification = sendOptions.Notification;

                // execute sending task
                var sendTask = sender.Send(notification, targetRecipients)
                    .ContinueWith((task, state) => Console.WriteLine($"{state} sender complete."), sendMethod);

                // add task to main collection
                sendTasks[Array.IndexOf(sendMethods, sendMethod)] = sendTask;
            }

            Task.WaitAll(sendTasks);
        }
    }

    public static class NotificationServiceFactory
    {
        public static INotificationService Create()
        {
            var senders = new NotificationSenderCollection
            {
                { NotificationSendMethod.Email, new EmailNotificationSender() }
            };

            return new NotificationService(senders);
        }
    }

    public class NotificationSenderCollection : Dictionary<NotificationSendMethod, INotificationSender>
    {
    }

    public class NotImplementedNotificationSender : Exception
    {
        public NotImplementedNotificationSender(NotificationSendMethod sendMethod)
            : base($"Notification sender not implemented for send method '{sendMethod}'.")
        {
        }
    }
}