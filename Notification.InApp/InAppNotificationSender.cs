using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.InApp
{
    public class InAppNotificationSender : NotificationSender<InAppNotification>
    {
        public override NotificationSendMethod SendMethod { get; } = NotificationSendMethod.InApp;

        protected override InAppNotification CreateNotification(INotification notification, INotificationRecipient recipient)
        {
            return new InAppNotification(notification);
        }

        protected override bool IsRecipientValid(INotificationRecipient recipient)
        {
            return recipient.GetDlsUserID() > 0;
        }

        protected override Task Execute(IEnumerable<InAppNotification> notifications)
        {
            return Task.Run(() => Task.Delay(300))
                .ContinueWith((t) => Console.WriteLine($"Sending {notifications.Count()} dls notification(s)..."));
        }
    }
}