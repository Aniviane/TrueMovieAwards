using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Configuration
{
    public class NotifyConfiguration : IEntityTypeConfiguration<Notify>
    {
        public void Configure(EntityTypeBuilder<Notify> builder)
        {
            builder.HasKey(x => new { x.UserId, x.NotificationId });

            builder.HasOne(x => x.User).WithMany(x => x.Notifies).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Notification).WithMany(x => x.Notifies).HasForeignKey(x => x.NotificationId);
           
        }
    }
}
