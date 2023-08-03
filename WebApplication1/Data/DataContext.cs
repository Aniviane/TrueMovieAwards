using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {

        private readonly DbContextOptions<DataContext> options;

        public DbSet<User> Users { get; set; }

        public DbSet<Award> Awards { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<ProducingMovie> Producings {get; set;}

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Notify> Notifies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Studio> Studios { get; set; }

        public DbSet<Festival> Festivals { get; set; }

        public DbSet<Holding> Holdings { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }

       
        public DataContext() : base()
        {

        }

        public DataContext(DbContextOptions<DataContext> options)  : base(options)
        {
         
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            mb.Entity<Movie>().HasOne(x => x.Studio).WithMany(x => x.Movies).HasForeignKey(x => x.StudioId).IsRequired(false);
            mb.Entity<Movie>().HasOne(x => x.Series).WithMany(x => x.Movies).HasForeignKey(x => x.SeriesId).IsRequired(false);

        } 

       
    }
}
