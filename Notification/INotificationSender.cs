﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification
{
    public interface INotificationSender
    {
        Task Send(INotification notification, IEnumerable<IRecipient> recipients);
    }
}