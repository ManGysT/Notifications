using System.Net.Mail;
using System.Threading.Tasks;

namespace Notification.Email
{
    public class EmailNotificationSender : INotificationSender<EmailNotification>
    {
        private readonly EmailSenderConfiguration configuration;

        public EmailNotificationSender(EmailSenderConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task Send(EmailNotification notification)
        {
            var smtp = new SmtpClient
            {
                Host = this.configuration.SmtpHost,
                Port = this.configuration.SmtpPort,
            };
            var mailMessage = new MailMessage
            {
                From = string.IsNullOrEmpty(notification.FromEmail)
                    ? new MailAddress(this.configuration.FromEmail, this.configuration.FromName)
                    : new MailAddress(notification.FromEmail, notification.FromName),
            };
            mailMessage.To.Add(new MailAddress(notification.ToEmail, notification.ToName));
            mailMessage.Subject = notification.Subject;
            mailMessage.Body = notification.Payload != null ? notification.Payload.ToString() : string.Empty;

            return smtp.SendMailAsync(mailMessage);
        }
    }
}