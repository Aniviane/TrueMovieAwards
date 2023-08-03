using System.Linq.Expressions;

namespace WebApplication1.Data.Models
{
    public class WatchList
    {
        public long ID { get; set; }

        public virtual List<Movie> Movies { get; set; }

        public virtual User User { get; set; }

        public long UserId { get; set; }

        public WatchList() {
            Movies = new List<Movie>();
        }
    }
}
