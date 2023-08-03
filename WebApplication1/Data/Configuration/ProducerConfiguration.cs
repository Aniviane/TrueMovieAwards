using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Configuration
{
    public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
    {


        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            
        }
    }
}
