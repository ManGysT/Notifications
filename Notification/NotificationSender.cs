using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification
{
    public abstract class NotificationSender<TNotification> : INotificationSender
    {
        public Task Send(Notification notification, IEnumerable<INotificationRecipient> recipients)
        {
            if (!recipients.Any())
            {
                return Task.CompletedTask;
            }

            Console.WriteLine($"Sending '{notification.NotificationName}' notification to {recipients.Count()} recipients.");

            var notifications = recipients
                .Select(x => this.NotificationFactory(notification, x));

            return this.Execute(notifications);
        }

        protected abstract Task Execute(IEnumerable<TNotification> notifications);

        protected abstract TNotification NotificationFactory(Notification notification, INotificationRecipient recipient);
    }
}