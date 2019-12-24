using Core.UserNotifications.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.UserNotifications
{
    public abstract class UserNotificationSender
    {
        public async Task Send(UserNotification notification, IEnumerable<UserNotificationRecipient> recipients)
        {
            await this.PerformSending(notification, recipients);
        }

        protected abstract Task PerformSending(UserNotification notification, IEnumerable<UserNotificationRecipient> recipients);
    }
}