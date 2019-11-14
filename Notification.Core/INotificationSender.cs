using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification
{
    public interface INotificationSender
    {
        NotificationSendMethod SendMethod { get; }
        Task Send(INotification notification, IEnumerable<INotificationRecipient> recipients);
    }
}