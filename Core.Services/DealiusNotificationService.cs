using Core.Interfaces;
using Core.Services.Logger;
using Notification;
using Notification.Email;
using Notification.InApp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class DealiusNotificationService : NotificationService<NotificationRecipient>
    {
        private readonly NotificationSendersCollection senders;
        private readonly ILogger logger;

        public DealiusNotificationService(NotificationSendersCollection senders, ILogger logger)
        {
            this.senders = senders;
            this.logger = logger;
        }

        protected override async Task Execute(INotification notification, IEnumerable<NotificationRecipient> recipients)
        {
            if (!recipients.Any())
            {
                this.logger.Debug($"No recipients to receive notifications.");
                return;
            }

            var tasks = this.senders
                    .Select(x => this.CreateSendTask(x.Key, x.Value, notification, recipients));

            await Task.WhenAll(tasks);
        }

        private async Task CreateSendTask(NotificationSendMethod sendMethod, INotificationSender sender, INotification notification, IEnumerable<NotificationRecipient> recipients)
        {
            var senderRecipients = recipients
                .Where(x => this.IsNotificationEnabled(x, notification, sendMethod));

            await sender.Send(notification, senderRecipients);
        }

        private bool IsNotificationEnabled(NotificationRecipient recipient, INotification notification, NotificationSendMethod sendMethod)
        {
            return true;
        }
    }

    public class NotificationsServiceFactory
    {
        public NotificationsServiceFactory()
        {
        }

        public INotificationService Create()
        {
            var senders = new NotificationSendersCollection
            {
                { NotificationSendMethod.Email, new EmailNotificationSenderFactory().Create() },
                { NotificationSendMethod.InApp, new InAppNotificationSenderFactory().Create() },
            };
            ILogger logger = new ConsoleLogger();

            return new DealiusNotificationService(senders, logger);
        }
    }

    public class NotificationSendersCollection : Dictionary<NotificationSendMethod, INotificationSender>
    {
    }

    public class NotificationRecipient : INotificationRecipient,
        IEmailNotificationRecipient,
        IInAppNotificationRecipient
    {
        public string Email { get; set; }
        public string FirstNameLastName { get; set; }
        public int? DealiusUserID { get; set; }

        public string UserNotificationSettingsJson { get; set; }
    }

    public enum NotificationSendMethod
    {
        None = 0,
        Email = 1,
        InApp = 2,

        All = Email | InApp
    }
}