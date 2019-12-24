namespace Notification.Email
{
    public interface IEmailRecipient : IRecipient
    {
        string Email { get; set; }
        string EmailName { get; set; }
        string EmailFriendlyName { get; set; }
    }
}