using System;

namespace Gighub.Core.Models
{
    public class UserNotification
    {
 
        public string UserId { get; private set; }

        public int NotificationId { get; private set; }

        //navigation properties
        public ApplicationUser User { get; private set; }

        public Notification Notification { get; private set; }

        public bool IsRead { get; set; }

        protected UserNotification()
        {

        }
        public UserNotification(ApplicationUser user, Notification notification)
        {
            if(user == null)
                throw  new ArgumentNullException("user");

            if(notification == null)
                throw  new ArgumentNullException("notification");

            User = user;
            Notification = notification;
        }

        public void Read()
        {

            IsRead = true;
        }
    }
}