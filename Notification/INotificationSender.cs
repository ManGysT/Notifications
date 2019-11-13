using System.Threading.Tasks;

namespace Notification
{
    public interface INotificationSender<TNotification> where TNotification : INotification
    {
        Task Send(TNotification notification);
    }
}