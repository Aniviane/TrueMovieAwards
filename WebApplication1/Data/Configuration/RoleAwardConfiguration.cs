using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Models;


namespace WebApplication1.Data.Configuration
{
    public class RoleAwardConfiguration : IEntityTypeConfiguration<RoleAward>
    {
        public void Configure(EntityTypeBuilder<RoleAward> builder)
        {
            builder.HasMany(x => x.Roles).WithMany(x => x.RoleAwards);
        }
    }
}
