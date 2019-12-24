using Core.Common.Interfaces;

namespace Infrastructure.UserNotifications
{
    public static class UserNotificationServiceFactory
    {
        public static IUserNotificationService Create(ISettingsManager settingsManager)
        {
            //INotificationSender emailSender = EmailSenderFactory.Create(settingsManager);

            var service = new UserNotificationService
            {
                //[UserNotificationSendMethod.Email] = emailSender
            };

            return service;
        }
    }

    //public static class EmailSenderFactory
    //{
    //    public static INotificationSender Create(ISettingsManager settingsManager)
    //    {
    //        var emailSenderConfig = new SendGridEmailSenderConfig
    //        {
    //            FromEmail = settingsManager.GetValue("Notifications:Email:FromEmail"),
    //            FromName = settingsManager.GetValue("Notifications:Email:FromName"),
    //            SendGridApiKey = settingsManager.GetValue("Notifications:Email:SendGridApiKey"),
    //        };
    //        INotificationSender emailSender = new SendGridEmailSender(emailSenderConfig);

    //        return emailSender;
    //    }
    //}
}