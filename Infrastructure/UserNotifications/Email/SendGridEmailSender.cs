using Core.UserNotifications.Models;
using Infrastructure.UserNotifications.Email.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.UserNotifications.Email
{
    public class SendGridEmailSender : UserNotificationSender
    {
        private readonly SendGridEmailSenderConfig config;

        public SendGridEmailSender(SendGridEmailSenderConfig config)
        {
            this.config = config;
        }

        protected override async Task PerformSending(UserNotification notification, IEnumerable<UserNotificationRecipient> recipients)
        {
            if (!EmailTemplate.TemplateExists(notification))
            {
                // TODO: log warning notification does not exist
                return;
            }

            var tasks = recipients
                .Select(x => this.PrepareSendEmailTask(notification, x));

            await Task.WhenAll(tasks);
        }

        private Task PrepareSendEmailTask(INotification notification, IEmailRecipient recipient)
        {
            var emailSubject = EmailTemplate.GetSubject(notification);
            var emailMessageContent = EmailTemplate.CompileTemplate(notification, recipient);

            //return Task.CompletedTask;
            var sendGridClient = new SendGrid.SendGridClient(this.config.SendGridApiKey);
            var sendGridMessage = new SendGrid.Helpers.Mail.SendGridMessage
            {
                From = new SendGrid.Helpers.Mail.EmailAddress(this.config.FromEmail, this.config.FromName),
                Subject = emailSubject,
                HtmlContent = emailMessageContent,
            };
            sendGridMessage.AddTo(recipient.Email, recipient.EmailName);

            return sendGridClient.SendEmailAsync(sendGridMessage);
        }
    }
}