using Core.UserNotifications.Models;

namespace Infrastructure.UserNotifications.Email.Models
{
    public class EmailViewModel
    {
        public UserNotification Data { get; set; }
        public UserNotificationRecipient Recipient { get; set; }
    }
}