using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification
{
    public abstract class NotificationSender<TRecipient> : INotificationSender
        where TRecipient : INotificationRecipient
    {
        public NotificationSender()
        {
        }

        public async Task Send(INotification notification, IEnumerable<INotificationRecipient> recipients)
        {
            if (!this.SupportsNotification(notification))
            {
                Console.WriteLine($"Notification '{notification.GetName()}' not supported by '{this.GetType().Name}'");
                return;
            }

            var senderRecipients = recipients.Cast<TRecipient>();
            var validRecipients = senderRecipients
                .Where(x => this.IsRecipientValid(x));

            if (!validRecipients.Any())
            {
                return;
            }

            await this.Execute(notification, validRecipients);
        }

        protected abstract bool SupportsNotification(INotification notification);

        protected abstract bool IsRecipientValid(TRecipient recipient);

        protected abstract Task Execute(INotification notification, IEnumerable<TRecipient> recipients);
    }
}