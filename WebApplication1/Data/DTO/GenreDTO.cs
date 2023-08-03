using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class GenreDTO
    {
        public long ID { get; set; }
        public string FName { get; set; }

        public List<PartialMovieDTO> Movies { get; set; } 

        public GenreDTO(Genre genre)
        {
            ID = genre.ID;
            FName = genre.FName;
            Movies = new List<PartialMovieDTO>();
            if(genre.Movies != null)
                foreach(var m in genre.Movies)
                {
                 Movies.Add(new PartialMovieDTO(m));
                }
        }

        public GenreDTO()
        {
        }
    }
}
