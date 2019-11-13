using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Email
{
    public class EmailNotificationSender : NotificationSender<EmailNotification>
    {
        protected override Task Execute(IEnumerable<EmailNotification> notifications)
        {
            return Task.Run(() => Task.Delay(2500))
                .ContinueWith((t) => Console.WriteLine($"Sending {notifications.Count()} email(s)..."));
        }

        protected override EmailNotification NotificationFactory(INotification notification, INotificationRecipient recipient)
        {
            return new EmailNotification(notification)
            {
                ToEmail = recipient.Email,
                ToName = recipient.FirstNameLastName,
            };
        }
    }
}