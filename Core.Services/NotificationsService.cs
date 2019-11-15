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
    public class NotificationsService : INotificationService
    {
        private readonly NotificationSendersCollection senders;
        private readonly ILogger logger;

        public NotificationsService(NotificationSendersCollection senders, ILogger logger)
        {
            this.senders = senders;
            this.logger = logger;
        }

        public async Task Send(INotification notification, IEnumerable<INotificationRecipient> recipients)
        {
            if (!recipients.Any())
            {
                this.logger.Debug($"No recipients to receive notifications.");
                return;
            }

            var tasks = this.senders
                    .Select(x => x.Value.Send(notification, recipients));

            await Task.WhenAll(tasks);

            // TODO: add handler for tasks results
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

            return new NotificationsService(senders, logger);
        }
    }

    public class NotificationSendersCollection : Dictionary<NotificationSendMethod, INotificationSender>
    {
    }

    public class NotificationRecipient : INotificationRecipient, IEmailNotificationRecipient, IInAppNotificationRecipient
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