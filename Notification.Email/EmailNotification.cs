namespace Notification.Email
{
    public class EmailNotification
    {
        public EmailNotification(INotification notification)
        {
            this.Notification = notification;
        }

        public INotification Notification { get; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string ToEmail { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
    }
}