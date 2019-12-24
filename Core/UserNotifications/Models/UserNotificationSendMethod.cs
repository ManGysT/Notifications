namespace Core.UserNotifications.Models
{
    public enum UserNotificationSendMethod
    {
        None = 0,
        Email = 1,
        InApp = 2,

        All = Email | InApp
    }
}