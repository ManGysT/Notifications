using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    public abstract class NotificationSender<TRecipient> : INotificationSender
        where TRecipient : IRecipient
    {
        public async Task Send(INotification notification, IEnumerable<IRecipient> recipients)
        {
            await this.PerformSending(notification, recipients.Cast<TRecipient>());
        }

        protected abstract Task PerformSending(INotification notification, IEnumerable<TRecipient> recipients);
    }
}