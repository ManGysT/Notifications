namespace Notification
{
    public interface INotification
    {
        bool RequiresAction { get; }
        string GetName();
    }
}