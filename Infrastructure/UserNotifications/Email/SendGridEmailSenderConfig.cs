namespace Infrastructure.UserNotifications.Email
{
    public class SendGridEmailSenderConfig
    {
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string SendGridApiKey { get; set; }
    }
}