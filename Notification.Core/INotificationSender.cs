using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification
{
    public interface INotificationSender
    {
        Task<NotificationSenderResult> Send(INotification notification, IEnumerable<INotificationRecipient> recipients);
    }
}