using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Configuration
{
    public class AwardConfiguration : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> builder)
        {

            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Holding).WithMany(x => x.Awards).HasForeignKey(x => x.HoldingId);


            builder.HasOne(x => x.Notification).WithOne(x => x.Award);


            builder.HasDiscriminator<string>("AwardType").HasValue<ProducerAward>("Producer").HasValue<RoleAward>("Role").HasValue<MovieAward>("Movie");

        }
    }
}
