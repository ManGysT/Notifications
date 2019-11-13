using System.Collections.Generic;

namespace Notification
{
    public interface INotificationSender
    {
        void Send(INotification notification, IEnumerable<INotificationRecipient> recipients);
    }
}