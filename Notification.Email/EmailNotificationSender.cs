using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Email
{
    public class EmailNotificationSender : NotificationSender<IEmailNotificationRecipient>
    {
        private readonly ConcurrentQueue<EmailNotification> emails;
        private readonly Worker[] workers;

        public EmailNotificationSender(EmailNotificationSenderConfig config)
        {
            this.emails = new ConcurrentQueue<EmailNotification>();
            this.workers = Enumerable.Range(1, config.MaxConcurrentTasks)
                .Select(x => new Worker(this))
                .ToArray();
        }

        protected override bool SupportsNotification(INotification notification)
        {
            return true;
        }

        protected override bool IsRecipientValid(IEmailNotificationRecipient recipient)
        {
            return !string.IsNullOrEmpty(recipient.Email);
        }

        protected override async Task Execute(INotification notification, IEnumerable<IEmailNotificationRecipient> recipients)
        {
            recipients
                .Select(x => new EmailNotification
                {
                    Notification = notification,
                    Recipient = x
                })
                .ToList()
                .ForEach(this.emails.Enqueue);

            Console.WriteLine($"Emails to send: {this.emails.Count}");

            await Task.WhenAll(
                this.workers.Select(x => x.Start())
                );
        }

        internal bool TryDequeue(out EmailNotification notification)
        {
            return this.emails.TryDequeue(out notification);
        }
    }
}