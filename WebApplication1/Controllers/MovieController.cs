using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public IMovie MovieService;

        public MovieController(IMovie Movie)
        {
            MovieService = Movie;
        }
        // GET: api/<MovieController>
        [HttpGet]
        public IEnumerable<MovieDTO> Get()
        {
            var ret = MovieService.GetMovies();
            return ret;
        }

        [HttpGet("Roles")]
        public IEnumerable<DownRoleDTO> GetRoles()
        {
            var ret = MovieService.GetRoles();
            return ret;
        }

        [HttpGet("Producings")]
        public IEnumerable<DownProducingMovieDTO> GetProducings()
        {
            var ret = MovieService.GetProducings();
            return ret;
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public MovieDTO Get(int id)
        {
            return MovieService.GetMovie(id);
        }

        // POST api/<MovieController>
        [HttpPost]
        public MovieDTO Post(MovieDTO Movie)
        {
            return MovieService.AddMovie(Movie);
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public MovieDTO Put(MovieDTO Movie)
        {
            return MovieService.UpdateMovie(Movie);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MovieService.DeleteMovie(id);
        }
    }
}
