using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Services;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        public IGenre GenreService;

        public GenresController(IGenre Genre)
        {
            GenreService = Genre;
        }
        // GET: api/<GenreController>
        [HttpGet]
        public IEnumerable<GenreDTO> Get()
        {
            var ret = GenreService.GetGenres();
            return ret;
        }


        [HttpPut("AddMovie")]
        public GenreDTO AddMovieToGenre(GenreMovieDTO genreMovieDTO)
        {
            return GenreService.AddMovie(genreMovieDTO);
        }
        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public GenreDTO Get(int id)
        {
            return GenreService.GetGenre(id);
        }

        // POST api/<GenreController>
        [HttpPost]
        public GenreDTO Post(GenreDTO Genre)
        {
            return GenreService.AddGenre(Genre);
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public GenreDTO Put(GenreDTO Genre)
        {
            return GenreService.UpdateGenre(Genre);
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            GenreService.DeleteGenre(id);
        }
    }
}
