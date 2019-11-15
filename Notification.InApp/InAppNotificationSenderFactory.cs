namespace Notification.InApp
{
    public class InAppNotificationSenderFactory : INotificationSenderFactory
    {
        public InAppNotificationSenderFactory()
        {
            // load default settings
            this.Config = new InAppNotificationSenderConfig();
        }

        public InAppNotificationSenderFactory(InAppNotificationSenderConfig config)
        {
            this.Config = config;
        }

        public InAppNotificationSenderConfig Config { get; }

        public INotificationSender Create()
        {
            return new InAppNotificationSender(this.Config);
        }
    }
}