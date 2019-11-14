using Notification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface INotificationService
    {
        Task Send(INotification notification, IEnumerable<INotificationRecipient> recipients);
    }
}