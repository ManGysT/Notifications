using Core.UserNotifications.Models;

namespace Core.UserNotifications.Models.Notifications
{
    public class MyNotification : UserNotification
    {
        public override bool RequiresAction => true;
        public override string Title => $"My notification title!";
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}