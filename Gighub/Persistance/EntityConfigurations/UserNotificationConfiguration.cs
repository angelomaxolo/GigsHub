using Gighub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Gighub.Persistance.EntityConfigurations
{
    public class UserNotificationConfiguration : EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguration()
        {
            HasKey(un => new {un.UserId, un.NotificationId});

            Property(un => un.UserId).HasColumnOrder(1);
            Property(un => un.NotificationId).HasColumnOrder(2);

            HasRequired(n => n.User)
                .WithMany(un => un.UserNotifications)
                .WillCascadeOnDelete(false);
        }
    }
}