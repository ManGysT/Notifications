namespace Notification
{
    public interface INotificationRecipient
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FirstNameLastName { get; set; }
        string FirstNameLastNameShort { get; set; }
    }
}