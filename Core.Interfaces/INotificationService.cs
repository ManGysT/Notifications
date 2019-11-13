using Notification;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interfaces
{
    public interface INotificationService
    {
        void Send(NotificationSendOptions sendOptions, IEnumerable<NotificationRecipient> recipients);
    }

    public class NotificationSendersCollection : Dictionary<NotificationSendMethod, INotificationSender<INotification>>
    {
    }

    public class NotificationSendOptions : INotification
    {
        public NotificationSendOptions(NotificationSendMethod methods)
        {
            this.Methods = methods;
        }

        public NotificationSendMethod Methods { get; }
        public NotificationName NotificationName { get; set; }
        public bool RequiresAction { get; set; }
        public object Payload { get; set; }
    }

    public enum NotificationSendMethod
    {
        None = 0,
        Email = 1,
        InApp = 2,

        All = Email | InApp
    }

    public static class NotificationSendMethodExtensions
    {
        public static NotificationSendMethod[] Enumerate(this NotificationSendMethod methods)
        {
            if (methods == NotificationSendMethod.None)
            {
                return new NotificationSendMethod[0];
            }

            return Enum.GetValues(typeof(NotificationSendMethod))
                .Cast<NotificationSendMethod>()
                .Where(x => x != NotificationSendMethod.None && x != NotificationSendMethod.All)
                .Where(x => methods.HasFlag(x))
                .ToArray();
        }
    }

    public class NotificationRecipient
    {
        public int? UserID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstNameLastName { get; set; }
        public string FirstNameLastNameShort { get; set; }
        public string NotificationsSettingsJson { get; set; }
    }
}