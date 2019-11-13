using Core.Interfaces;
using Notification;
using Notification.Email;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationSendersCollection senders;

        public NotificationService(NotificationSendersCollection senders)
        {
            this.senders = senders;
        }

        public void Send(NotificationSendOptions sendOptions, IEnumerable<NotificationRecipient> recipients)
        {
            foreach (var sendMethod in sendOptions.Methods.Enumerate())
            {
                INotificationSender sender;
                if (!this.senders.TryGetValue(sendMethod, out sender))
                {
                    throw new System.Exception("Sender not found");
                }

                sender.Send(sendOptions);
            }
        }
    }

    public class NotificationServiceFactory
    {
        public static INotificationService Create()
        {
            var senders = new NotificationSendersCollection();

            Func<EmailSenderConfiguration> emailSenderConfigFactory = () => new EmailSenderConfiguration();
            var emailSenderFactory = new EmailNotificationSenderFactory(emailSenderConfigFactory);
            senders.Add(NotificationSendMethod.Email, emailSenderFactory.Create());

            return new NotificationService(senders);
        }
    }
}