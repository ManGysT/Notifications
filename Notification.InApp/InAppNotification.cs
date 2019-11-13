using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.InApp
{
    public class InAppNotification
    {
        public InAppNotification(Notification notification)
        {
            this.Notification = notification;
        }

        public Notification Notification { get; }
    }
}