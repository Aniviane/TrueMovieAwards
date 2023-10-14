using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IMovie
    {
        public MovieDTO AddMovie(MovieCreateDTO Movie);

        public List<MovieDTO> GetMovies();

        public void UpdatePhoto(PhotoUpdateDTO photoUpdateDTO);
        public MovieDTO GetMovie(long id);

        public RightRoleDTO UpdateRole(RightRoleDTO dto);

        public void DeleteRole(long id);

        public void DeleteProducing(DownProducingMovieDTO dto);
        public MovieDTO UpdateMovie(MovieDTO Movie);

        public void DeleteMovie(long id);

        public List<DownRoleDTO> GetRoles();
        public List<DownProducingMovieDTO> GetProducings();


       
    }
}
