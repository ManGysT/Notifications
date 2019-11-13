using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Notification.Email
{
    public class EmailNotificationSender : NotificationSender<EmailNotification>
    {
        private readonly EmailSenderConfiguration configuration;

        public EmailNotificationSender(EmailSenderConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override EmailNotification CreateNotification(INotification notification, INotificationRecipient recipient)
        {
            return new EmailNotification(notification);
        }

        protected override void Execute(IEnumerable<EmailNotification> notifications)
        {
            Console.WriteLine($"Sending email to {notification.ToEmail}");
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

        private SmtpClient GetSmtp()
        {
            return new SmtpClient
            {
                Host = this.configuration.SmtpHost,
                Port = this.configuration.SmtpPort,
            };
        }
    }
}