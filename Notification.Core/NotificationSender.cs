using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification
{
    public abstract class NotificationSender<TSenderNotification> : INotificationSender
    {
        public NotificationSender()
        {
        }

        public abstract NotificationSendMethod SendMethod { get; }

        public Task Send(INotification notification, IEnumerable<INotificationRecipient> recipients)
        {
            var validRecipients = recipients
                .Where(this.IsRecipientValid);

            if (!validRecipients.Any())
            {
                return Task.CompletedTask;
            }

            var notifications = validRecipients
                .Where(x => x.NotificationEnabled(notification.GetName(), this.SendMethod)) // filter out recipients with turned off notification
                .Select(x => this.CreateNotification(notification, x));

            if (!notifications.Any())
            {
                return Task.CompletedTask;
            }

            return this.Execute(notifications);
        }

        protected abstract TSenderNotification CreateNotification(INotification notification, INotificationRecipient recipient);

        protected abstract bool IsRecipientValid(INotificationRecipient recipient);

        protected abstract Task Execute(IEnumerable<TSenderNotification> notifications);
    }
}