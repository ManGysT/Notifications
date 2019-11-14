using Core.Interfaces;
using Core.Services.Logger;
using Notification;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class NotificationsService : INotificationService
    {
        private readonly IEnumerable<INotificationSender> senders;
        private readonly ILogger logger;

        public NotificationsService(IEnumerable<INotificationSender> senders, ILogger logger)
        {
            this.senders = senders;
            this.logger = logger;
        }

        public Task Send(INotification notification, IEnumerable<INotificationRecipient> recipients)
        {
            if (!recipients.Any())
            {
                this.logger.Debug($"No recipients to receive notifications.");
                return Task.CompletedTask;
            }

            return Task.Factory.StartNew(() => { }, TaskCreationOptions.);
        }
    }

    public class NotificationsServiceFactory
    {
        public NotificationsServiceFactory()
        {
        }

        public INotificationService Create()
        {
            var senders = new List<INotificationSender>();
            ILogger logger = new ConsoleLogger();

            return new NotificationsService(senders, logger);
        }
    }

    public class NotificationRecipient : INotificationRecipient
    {
        public int? UserID { get; set; }
        public string Email { get; set; }
        public string FirstNameLastName { get; set; }
        public string UserNotificationSettingsJson { get; set; }

        public bool NotificationEnabled(string notificationName, NotificationSendMethod sendMethod)
        {
            return true;
        }

        public string GetEmail()
        {
            return this.Email;
        }

        public string GetEmailName()
        {
            return this.FirstNameLastName;
        }

        public int? GetDlsUserID()
        {
            return this.UserID;
        }
    }
}