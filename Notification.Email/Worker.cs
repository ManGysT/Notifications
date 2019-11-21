using System;
using System.Threading.Tasks;

namespace Notification.Email
{
    internal class Worker
    {
        private readonly EmailNotificationSender sender;

        public Worker(EmailNotificationSender sender)
        {
            this.sender = sender;
        }

        public async Task Start()
        {
            EmailNotification notification;
            while (this.sender.TryDequeue(out notification))
            {
                await this.SendEmail(notification);
            }
        }

        private async Task SendEmail(EmailNotification emailNotification)
        {
            //Console.WriteLine($"Sending email to '{emailNotification.Recipient.Email}'.");

            var delayMs = new Random(Guid.NewGuid().GetHashCode()).Next(100, 1000);
            await Task.Delay(delayMs);

            Console.WriteLine($"Email successfully sent to '{emailNotification.Recipient.Email}', time: {TimeSpan.FromMilliseconds(delayMs)}!");
        }
    }
}