using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Models;


namespace WebApplication1.Data.Configuration
{
    public class ProducingAwardConfiguration : IEntityTypeConfiguration<ProducerAward>
    {
        public void Configure(EntityTypeBuilder<ProducerAward> builder)
        {
            builder.HasMany(x => x.Producings).WithMany(x => x.ProducerAwards);
        }
    }
}
