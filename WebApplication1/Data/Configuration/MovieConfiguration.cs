using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Studio).WithMany(x => x.Movies).HasForeignKey(x => x.StudioId).IsRequired(false);
            builder.HasMany(x => x.Genres).WithMany(x => x.Movies);
            builder.HasOne(x => x.Series).WithMany(x => x.Movies).HasForeignKey(x => x.SeriesId).IsRequired(false);


        }
    }
}
