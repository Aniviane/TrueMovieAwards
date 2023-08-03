using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Models;


namespace WebApplication1.Data.Configuration
{
    public class MovieAwardConfiguration : IEntityTypeConfiguration<MovieAward>
    {
        public void Configure(EntityTypeBuilder<MovieAward> builder)
        {
            builder.HasMany(x => x.Movies).WithMany(x => x.MovieAwards);
        }
    }
}
