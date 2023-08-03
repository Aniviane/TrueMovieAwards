using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IMovie
    {
        public MovieDTO AddMovie(MovieDTO Movie);

        public List<MovieDTO> GetMovies();

        public MovieDTO GetMovie(long id);

        public MovieDTO UpdateMovie(MovieDTO Movie);

        public void DeleteMovie(long id);

        public List<DownRoleDTO> GetRoles();
        public List<DownProducingMovieDTO> GetProducings();


       
    }
}
