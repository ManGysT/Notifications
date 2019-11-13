namespace Notification
{
    public interface INotification
    {
        NotificationName NotificationName { get; }
        bool RequiresAction { get; set; }
    }

    public enum NotificationName
    {
        DealCloseRequest = 1,
        DealCloseApprove = 2,
        DealCloseReject = 3,
    }
}