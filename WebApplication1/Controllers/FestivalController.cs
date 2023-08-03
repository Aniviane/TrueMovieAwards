using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalController : ControllerBase
    {
        public IFestival FestivalService;

        public FestivalController(IFestival Festival)
        {
            FestivalService = Festival;
        }
        // GET: api/<FestivalController>
        [HttpGet]
        public IEnumerable<FestivalDTO> Get()
        {
            var ret = FestivalService.GetFestivals();
            return ret;
        }

        // GET api/<FestivalController>/5
        [HttpGet("{id}")]
        public FestivalDTO Get(int id)
        {
            return FestivalService.GetFestival(id);
        }

        // POST api/<FestivalController>
        [HttpPost]
        public FestivalDTO Post(FestivalDTO Festival)
        {
            return FestivalService.AddFestival(Festival);
        }

        // PUT api/<FestivalController>/5
        [HttpPut("{id}")]
        public FestivalDTO Put(FestivalDTO Festival)
        {
            return FestivalService.UpdateFestival(Festival);
        }

        // DELETE api/<FestivalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FestivalService.DeleteFestival(id);
        }
    }
}
