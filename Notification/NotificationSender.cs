using System.Collections.Generic;
using System.Linq;

namespace Notification
{
    public abstract class NotificationSender<TNotification> : INotificationSender where TNotification : class
    {
        protected NotificationSender()
        {
        }

        public virtual void Send(INotification notification, IEnumerable<INotificationRecipient> recipients)
        {
            var notificationsToSend = recipients
                .Select(x => this.CreateNotification(notification, x));

            this.Execute(notificationsToSend);
        }

        protected abstract TNotification CreateNotification(INotification notification, INotificationRecipient recipient);

        protected abstract void Execute(IEnumerable<TNotification> notifications);
    }
}