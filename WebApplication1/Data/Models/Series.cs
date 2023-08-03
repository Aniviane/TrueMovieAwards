using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class Series
    {
        public long ID { get; set; }
        public string FName { get; set; }

        public virtual List<Movie> Movies { get; set; }

        public Series() { }

        public Series(SeriesDTO series)
        {
            FName = series.FName;
            Movies = new List<Movie>();
            
        }
    }
}
