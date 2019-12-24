namespace Core.UserNotifications.Models
{
    public abstract class UserNotification
    {
        public abstract bool RequiresAction { get; }
        public abstract string Title { get; }
        public string GetName() => this.GetType().Name;
    }
}
