using Gighub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Gighub.Persistance.EntityConfigurations
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasRequired(g => g.Gig);

        }
    }
}