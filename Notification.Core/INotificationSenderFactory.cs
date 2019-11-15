namespace Notification
{
    public interface INotificationSenderFactory
    {
        INotificationSender Create();
    }
}