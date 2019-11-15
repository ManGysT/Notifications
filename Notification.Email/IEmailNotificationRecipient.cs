namespace Notification.Email
{
    public interface IEmailNotificationRecipient : INotificationRecipient
    {
        string Email { get; set; }
        string FirstNameLastName { get; set; }
    }
}