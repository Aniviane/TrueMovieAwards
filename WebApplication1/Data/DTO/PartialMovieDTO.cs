using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class PartialMovieDTO
    {
        public long ID  { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string Photo { get; set; }

        public PartialMovieDTO(Movie movie)
        {
            ID = movie.ID;
            Title = movie.Title;
            Description = movie.Description;
            Photo = movie.Photo;
        }

        public PartialMovieDTO()
        {
        }
    }
}
