namespace Infrastructure.UserNotifications.Email.Models
{
    public class EmailViewModel
    {
        public INotification Data { get; set; }
        public IEmailRecipient Recipient { get; set; }
    }
}