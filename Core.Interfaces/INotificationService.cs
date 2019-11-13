using Core.Interfaces.Notifications;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface INotificationService
    {
        void Send(NotificationSendOptions sendOptions, IEnumerable<NotificationRecipient> recipients);
    }
}