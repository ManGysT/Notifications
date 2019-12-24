using Core.Common.Interfaces;
using Core.UserNotifications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.UserNotifications
{
    public class UserNotificationService : Dictionary<UserNotificationSendMethod, UserNotificationSender>, IUserNotificationService
    {
        public UserNotificationService()
            : base(10)
        {
        }

        public UserNotificationService(IDictionary<UserNotificationSendMethod, UserNotificationSender> senders)
            : base(senders)
        {
        }

        public async Task Send(UserNotification notification, IEnumerable<UserNotificationRecipient> recipients)
        {
            Console.WriteLine($"Sending '{notification.GetName()}' to {recipients.Count()} recipient(s).");

            var sendTasks = this.Values
                .Select(x => x.Send(notification, recipients));

            await Task.WhenAll(sendTasks);
        }
    }
}