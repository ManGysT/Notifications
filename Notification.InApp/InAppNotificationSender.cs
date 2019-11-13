using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.InApp
{
    public class InAppNotificationSender : NotificationSender<InAppNotification>
    {
        protected override Task Execute(IEnumerable<InAppNotification> notifications)
        {
            return Task.Run(() => Task.Delay(300))
                .ContinueWith((t) => Console.WriteLine($"Sending {notifications.Count()} dls notification(s)..."));
        }

        protected override InAppNotification NotificationFactory(Notification notification, INotificationRecipient recipient)
        {
            return new InAppNotification(notification);
        }
    }
}
