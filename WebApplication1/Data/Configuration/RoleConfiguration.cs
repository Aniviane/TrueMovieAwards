using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Actor).WithMany(x => x.Roles).HasForeignKey(x => x.ActorId);
            builder.HasOne(x => x.Movie).WithMany(x => x.Roles).HasForeignKey(x => x.MovieId);

        }
    }
}
