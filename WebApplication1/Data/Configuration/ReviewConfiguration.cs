using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Models;


namespace WebApplication1.Data.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Reviewer).WithMany(x => x.Reviews).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Movie).WithMany(x => x.Reviews).HasForeignKey(x => x.MovieId);
        }
    }
}
