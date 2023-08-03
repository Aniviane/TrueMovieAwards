using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.HasMany(x => x.FavActors).WithMany(x => x.Favorites);
            builder.HasMany(x => x.FavMovies).WithMany(x => x.Favorites);
            builder.HasMany(x => x.FavProducers).WithMany(x => x.Favorites);
            builder.HasMany(x => x.Reviews).WithOne(x => x.Reviewer);

           


        }
    }
}
