using System;
using System.Linq;

namespace Core.Interfaces.Notifications
{
    public enum NotificationSendMethod
    {
        None = 0,
        Email = 1,
        InApp = 2,

        All = Email | InApp
    }

    public static class NotificationSendMethodExtensions
    {
        public static NotificationSendMethod[] Enumerate(this NotificationSendMethod methods)
        {
            if (methods == NotificationSendMethod.None)
            {
                return new NotificationSendMethod[0];
            }

            return Enum.GetValues(typeof(NotificationSendMethod))
                .Cast<NotificationSendMethod>()
                .Where(x => x != NotificationSendMethod.None && x != NotificationSendMethod.All)
                .Where(x => methods.HasFlag(x))
                .ToArray();
        }
    }
}
