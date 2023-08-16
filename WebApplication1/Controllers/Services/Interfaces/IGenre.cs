using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IGenre
    {
        public GenreDTO AddGenre(GenreDTO Genre);

        public List<GenreDTO> GetGenres();

        public GenreDTO GetGenre(long id);

        public GenreDTO UpdateGenre(GenreDTO Genre);

        public void DeleteGenre(long id);

        public GenreDTO AddMovie(GenreMovieDTO genreMovieDTO);
    }
}
