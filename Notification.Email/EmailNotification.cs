namespace Notification.Email
{
    internal class EmailNotification
    {
        public INotification Notification { get; set; }
        public IEmailNotificationRecipient Recipient { get; set; }
    }
}