using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Models;


namespace WebApplication1.Data.Configuration
{
    public class ProducingMovieConfiguration : IEntityTypeConfiguration<ProducingMovie>
    {
        public void Configure(EntityTypeBuilder<ProducingMovie> builder)
        {
            builder.HasKey(x => new { x.MovieId, x.ProducerId });

            builder.HasOne(x => x.Movie).WithMany(x => x.Producings).HasForeignKey(x => x.MovieId);
            builder.HasOne(x => x.Producer).WithMany(x => x.Producings).HasForeignKey(x => x.ProducerId);

        }
    }
}
