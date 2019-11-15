namespace Notification.Email
{
    public class EmailNotificationSenderConfig
    {
        public string SmtpHost { get; set; }
        public int? SmtpPort { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public int MaxConcurrentTasks { get; set; } = 10;
    }
}