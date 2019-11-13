namespace Core.Interfaces.Notifications
{
    public class NotificationSendOptions
    {
        public NotificationSendOptions(NotificationSendMethod sendMethod)
        {
            this.SendMethod = sendMethod;
        }

        public NotificationSendMethod SendMethod { get; }
        public Notification.Notification Notification { get; set; }
    }
}