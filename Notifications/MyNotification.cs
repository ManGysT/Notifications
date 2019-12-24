using Notification;

namespace Notifications
{
    public class MyNotification : INotification
    {
        public bool RequiresAction => true;
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string GetName() => this.GetType().Name;
        public string GetTitle() => $"My notification title!";
    }
}