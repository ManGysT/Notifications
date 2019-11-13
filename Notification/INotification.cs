namespace Notification
{
    public interface INotification
    {
        NotificationName NotificationName { get; set; }
        bool RequiresAction { get; set; }
        object Payload { get; set; }
    }

    public enum NotificationName
    {
        DealCloseRequest = 1,
        DealCloseApprove = 2,
        DealCloseReject = 3,
    }
}
