namespace Notification
{
    public interface INotificationRecipient
    {
        bool NotificationEnabled(string notificationName, NotificationSendMethod sendMethod);

        string GetEmail();
        string GetEmailName();
        int? GetDlsUserID();
    }
}