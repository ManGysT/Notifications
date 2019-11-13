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
            Console.WriteLine($"Sending '{notification.NotificationName}' notification to {recipients.Count()} recipients.");

            return Task.CompletedTask;
        }
    }
}