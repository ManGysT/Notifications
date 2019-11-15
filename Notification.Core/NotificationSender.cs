using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification
{
    public abstract class NotificationSender<TRecipient> : INotificationSender
        where TRecipient : INotificationRecipient
    {
        private readonly List<TRecipient> invalidRecpients = new List<TRecipient>();

        public NotificationSender()
        {
        }

        public async Task<NotificationSenderResult> Send(INotification notification, IEnumerable<INotificationRecipient> recipients)
        {
            if (!this.SupportsNotification(notification))
            {
                Console.WriteLine($"Notification '{notification.GetName()}' not supported by '{this.GetType().Name}'");
                return NotificationSenderResult.Empty();
            }

            var senderRecipients = recipients.Cast<TRecipient>();
            var validRecipients = senderRecipients
                .Where(x => this.IsRecipientValid(x));

            this.invalidRecpients.AddRange(senderRecipients.Except(validRecipients));

            if (!validRecipients.Any())
            {
                return NotificationSenderResult.Empty();
            }

            await this.Execute(notification, validRecipients)
                .ContinueWith(t => Console.WriteLine($"{this.GetInvalidRecipients().Count()} invalid recipients detected."));

            return this.SummariseResult();
        }

        protected abstract bool SupportsNotification(INotification notification);

        protected abstract bool IsRecipientValid(TRecipient recipient);

        protected abstract Task Execute(INotification notification, IEnumerable<TRecipient> recipients);

        protected IEnumerable<TRecipient> GetInvalidRecipients()
        {
            return this.invalidRecpients;
        }

        protected virtual NotificationSenderResult SummariseResult()
        {
            var result = new NotificationSenderResult();
            result.InvalidRecipients.AddRange(this.GetInvalidRecipients().Cast<INotificationRecipient>());

            return result;
        }
    }
}