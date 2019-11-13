using Notification;

namespace Core.Interfaces.Notifications
{
    public class NotificationRecipient : INotificationRecipient
    {        
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstNameLastName { get; set; }
        public string FirstNameLastNameShort { get; set; }

        public string NotificationsSettingsJson { get; set; }
    }
}