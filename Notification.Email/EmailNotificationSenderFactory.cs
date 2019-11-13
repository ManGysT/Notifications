namespace Notification.Email
{
    public class EmailNotificationSenderFactory : INotificationSenderFactory<EmailNotification>
    {
        public EmailNotificationSenderFactory(EmailSenderConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public EmailSenderConfiguration Configuration { get; }

        public INotificationSender<EmailNotification> Create()
        {
            return new EmailNotificationSender(this.Configuration);
        }
    }
}
