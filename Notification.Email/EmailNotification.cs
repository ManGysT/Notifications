namespace Notification.Email
{
    public class EmailNotification : INotification
    {
        public NotificationName NotificationName { get; set; }
        public bool RequiresAction { get; set; }
        public object Payload { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string ToEmail { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
    }
}