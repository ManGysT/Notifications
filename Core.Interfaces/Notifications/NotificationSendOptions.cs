using Notification;

namespace Core.Interfaces.Notifications
{
    public class NotificationSendOptions
    {
        public NotificationSendOptions(NotificationSendMethod sendMethod)
        {
            this.SendMethod = sendMethod;
        }

        public NotificationSendMethod SendMethod { get; }
        public INotification Notification { get; set; }
    }
}