using Notification;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface INotificationService
    {
        Task Send(INotification notification, IEnumerable<INotificationRecipient> recipients);
    }

    public abstract class NotificationService<TRecipient> : INotificationService
        where TRecipient : INotificationRecipient
    {
        public Task Send(INotification notification, IEnumerable<INotificationRecipient> recipients)
        {
            return this.Execute(notification, recipients.Cast<TRecipient>());
        }

        protected abstract Task Execute(INotification notification, IEnumerable<TRecipient> recipients);
    }
}