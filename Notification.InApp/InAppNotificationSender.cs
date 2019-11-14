using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.InApp
{
    public class InAppNotificationSender : NotificationSender<IInAppNotificationRecipient>
    {
        public InAppNotificationSender(InAppNotificationSenderConfig config)
        {
        }

        protected override bool SupportsNotification(INotification notification)
        {
            return false;
        }

        protected override bool IsRecipientValid(IInAppNotificationRecipient recipient)
        {
            return recipient.DealiusUserID > 0;
        }

        protected override async Task Execute(INotification notification, IEnumerable<IInAppNotificationRecipient> recipients)
        {
            Console.WriteLine($"Initializing database...");

            await Task.Run(() => Task.Delay(1000))
                .ContinueWith((t) => Console.WriteLine($"Establishing connection..."))
                .ContinueWith(async (t) => await Task.Delay(1500))
                .ContinueWith((t) => Console.WriteLine($"Sending {recipients.Count()} dls notification(s)..."))
                .ContinueWith(async (t) => await Task.Delay(2500))
                .ContinueWith((t) => Console.WriteLine($"{recipients.Count()} dls notification(s) successfully sent!"));
        }
    }
}