using Core.UserNotifications.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Common.Interfaces
{
    public interface IUserNotificationService
    {
        Task Send(UserNotification notification, IEnumerable<UserNotificationRecipient> recipients);
    }
}