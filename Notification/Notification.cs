namespace Notification
{
    public class Notification
    {
        public NotificationName NotificationName { get; set; }
        public bool RequiresAction { get; set; }
        public object Payload { get; set; }
    }

    public enum NotificationName
    {
        DealCloseRequest = 1,
        DealCloseApprove = 2,
        DealCloseReject = 3,
    }
}