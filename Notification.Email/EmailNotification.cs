namespace Notification.Email
{
    public class EmailNotification
    {
        public EmailNotification(Notification notification)
        {
            this.Notification = notification;
        }

        public Notification Notification { get; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string ToEmail { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
    }
}