namespace Notification.Email
{
    public class EmailNotificationSenderFactory : INotificationSenderFactory
    {
        public EmailNotificationSenderFactory()
        {
            // load default settings
            this.Config = new EmailNotificationSenderConfig();
        }

        public EmailNotificationSenderFactory(EmailNotificationSenderConfig config)
        {
            this.Config = config;
        }

        public EmailNotificationSenderConfig Config { get; }

        public INotificationSender Create()
        {
            return new EmailNotificationSender(this.Config);
        }
    }
}