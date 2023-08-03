using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class WatchListDTO
    {
        public long ID { get; set; }

        public List<PartialMovieDTO> Movies { get; set; }



        public WatchListDTO(WatchList watchList)
        {
            ID = watchList.ID;
            Movies = new List<PartialMovieDTO>();
            foreach(var m in watchList.Movies)
            {
                Movies.Add(new PartialMovieDTO(m));
            }
        }

        public WatchListDTO()
        {
        }
    }
}
