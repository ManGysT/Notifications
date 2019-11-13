using System;

namespace Notification.Email
{
    public class EmailNotificationSenderFactory : INotificationSenderFactory
    {
        public EmailNotificationSenderFactory(Func<EmailSenderConfiguration> configurationFactory)
        {
            this.ConfigurationFactory = configurationFactory;
        }

        public Func<EmailSenderConfiguration> ConfigurationFactory { get; }

        public INotificationSender Create()
        {
            return new EmailNotificationSender(this.ConfigurationFactory());
        }
    }
}
