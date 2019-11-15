using System.Collections.Generic;

namespace Notification
{
    public class NotificationSenderResult
    {
        public List<INotificationRecipient> InvalidRecipients { get; set; } = new List<INotificationRecipient>();

        public static NotificationSenderResult Empty()
        {
            return new NotificationSenderResult();
        }
    }
}