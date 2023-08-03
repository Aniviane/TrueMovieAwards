using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        public ISeries SeriesService;

        public SeriesController(ISeries Series)
        {
            SeriesService = Series;
        }
        // GET: api/<SeriesController>
        [HttpGet]
        [Authorize(Roles = "Moderator")]
        public IEnumerable<SeriesDTO> Get()
        {
            var ret = SeriesService.GetSeries();
            return ret;
        }

        // GET api/<SeriesController>/5
        [HttpGet("{id}")]
        public SeriesDTO Get(int id)
        {
            return SeriesService.GetSeries(id);
        }

        // POST api/<SeriesController>
        [HttpPost]
        [Authorize(Roles = "Moderator")]
        public SeriesDTO Post(SeriesDTO Series)
        {
            return SeriesService.AddSeries(Series);
        }

        [HttpPost("AddMovie")]
        public SeriesDTO AddMovie(SeriesDTO Series)
        {
            return SeriesService.AddMovie(Series);
        }


        // PUT api/<SeriesController>/5
        [HttpPut("{id}")]
        public SeriesDTO Put(SeriesDTO Series)
        {
            return SeriesService.UpdateSeries(Series);
        }

        // DELETE api/<SeriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SeriesService.DeleteSeries(id);
        }
    }
}
