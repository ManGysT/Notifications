using Core.Interfaces;
using Notification;
using Notification.Email;
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
                INotificationSender<INotification> sender;
                if (this.senders.TryGetValue(sendMethod, out sender))
                {
                    throw new System.Exception("Sender not found");
                }

                //sender.Send(sendOptions);
            }
        }
    }

    public class NotificationServiceFactory
    {
        public static INotificationService Create()
        {
            var senders = new NotificationSendersCollection();

            var emailSenderConfig = new EmailSenderConfiguration();
            var emailSenderFactory = new EmailNotificationSenderFactory(emailSenderConfig);
            senders.Add(NotificationSendMethod.Email, (INotificationSender<INotification>)emailSenderFactory.Create());

            return new NotificationService(senders);
        }
    }
}