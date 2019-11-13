namespace Notification
{
    public interface INotificationSenderFactory<TNotification> where TNotification : INotification
    {
        INotificationSender<TNotification> Create();
    }
}