using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Services;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        public IStudio StudioService;

        public StudioController(IStudio Studio)
        {
            StudioService = Studio;
        }
        // GET: api/<StudioController>
        [HttpGet]
        public IEnumerable<StudioDTO> Get()
        {
            var ret = StudioService.GetStudios();
            return ret;
        }

        // GET api/<StudioController>/5
        [HttpGet("{id}")]
        public StudioDTO Get(int id)
        {
            return StudioService.GetStudio(id);
        }

        // POST api/<StudioController>
        [HttpPost]
        public StudioDTO Post([FromForm] StudioCreateDTO Studio)
        {
            return StudioService.AddStudio(Studio);
        }

        [HttpPost("AddMovie")]
        public StudioDTO AddMovie(StudioDTO studio)
        {
            return StudioService.AddMovie(studio);
        }


        // PUT api/<StudioController>/5
        [HttpPut("{id}")]
        public StudioDTO Put(StudioDTO Studio)
        {
            return StudioService.UpdateStudio(Studio);
        }

        // DELETE api/<StudioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            StudioService.DeleteStudio(id);
        }

        [HttpPut("UpdatePhoto")]
        public void updatePhoto([FromForm] PhotoUpdateDTO dto)
        {
            StudioService.UpdatePhoto(dto);
        }
    }
}
