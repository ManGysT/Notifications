namespace Notification.Email
{
    public class EmailSenderConfiguration
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
    }
}