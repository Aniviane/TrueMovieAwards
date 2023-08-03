using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class SeriesDTO
    {
        public long ID { get; set; }
        public string FName { get; set; }

        public List<PartialMovieDTO> Movies { get; set; }

        public SeriesDTO(Series series)
        {
            ID = series.ID;
            FName = series.FName;
            Movies = new List<PartialMovieDTO>();
            if (series.Movies != null)
                foreach(var m  in series.Movies)
                {
                    Movies.Add(new PartialMovieDTO(m));
                }
        }

        public SeriesDTO()
        {
        }
    }
}
