using Core.UserNotifications.Models;

namespace Infrastructure.UserNotifications.Email.Internal
{
    class EmailTemplate
    {
        private const string TemplatesPath = "Notification.Email.Templates.{0}.cshtml";

        public static string GetSubject(UserNotification notification)
        {
            var output = notification.Title;
            if (notification.RequiresAction)
            {
                output = string.Concat("Action: ", output);
            }

            return output;
        }

        public static string GetTemplateName(UserNotification notification)
        {
            return string.Format(TemplatesPath, notification.GetName());
        }

        public static string GetTemplate(UserNotification notification)
        {
            var templateName = EmailTemplate.GetTemplateName(notification);
            return ResourceHelper.GetResource(templateName);
        }

        public static bool TemplateExists(UserNotification notification)
        {
            var templateName = EmailTemplate.GetTemplateName(notification);
            return ResourceHelper.Exists(templateName);
        }

        public static string CompileTemplate(UserNotification notification, UserNotificationRecipient recipient)
        {
            var templateViewModel = GetTemplateViewModel(notification, recipient);
            var templateName = string.Concat("Templates.", notification.GetName());
            var output = RazorTemplate.Compile(templateName, templateViewModel);

            return output;
        }

        public static Models.EmailViewModel GetTemplateViewModel(UserNotification notification, UserNotificationRecipient recipient)
        {
            return new Models.EmailViewModel
            {
                Data = notification,
                Recipient = recipient,
            };
        }
    }
}