using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification
{
    public interface INotificationSender
    {
        Task Send(Notification notification, IEnumerable<INotificationRecipient> recipients);
    }
}