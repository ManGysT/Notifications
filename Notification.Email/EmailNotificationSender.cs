using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Email
{
    public class EmailNotificationSender : NotificationSender<EmailNotification>
    {
        public override NotificationSendMethod SendMethod { get; } = NotificationSendMethod.Email;

        protected override EmailNotification CreateNotification(INotification notification, INotificationRecipient recipient)
        {
            return new EmailNotification(notification)
            {
                ToEmail = recipient.GetEmail(),
                ToName = recipient.GetEmailName(),
            };
        }

        protected override bool IsRecipientValid(INotificationRecipient recipient)
        {
            return !string.IsNullOrEmpty(recipient.GetEmail());
        }

        protected override Task Execute(IEnumerable<EmailNotification> notifications)
        {
            return Task.Run(() => Task.Delay(2500))
                .ContinueWith((t) => Console.WriteLine($"Sending {notifications.Count()} email(s)..."));
        }
    }
}