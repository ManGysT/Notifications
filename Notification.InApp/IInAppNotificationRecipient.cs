namespace Notification.InApp
{
    public interface IInAppNotificationRecipient : INotificationRecipient
    {
        int? DealiusUserID { get; set; }
    }
}