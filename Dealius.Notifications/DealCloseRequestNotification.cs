using Notification;

namespace Dealius.Notifications
{
    public class DealCloseRequestNotification : INotification
    {
        public int DealID { get; set; }
        public string DealName { get; set; }
        public string DealProfileUrl { get; set; }
        public bool RequiresAction { get; } = true;

        public string GetName()
        {
            return this.GetType().Name;
        }
    }
}