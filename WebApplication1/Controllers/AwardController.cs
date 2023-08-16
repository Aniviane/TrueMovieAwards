using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardController : ControllerBase
    {
        public IAward AwardService;

        public AwardController(IAward Award)
        {
            AwardService = Award;
        }
        // GET: api/<AwardController>
        [HttpGet]
        public IEnumerable<AwardWrapperDTO> Get()
        {
            var ret = AwardService.GetAwards();
            return ret;
        }

        // GET api/<AwardController>/5
        [HttpGet("{id}")]
        public AwardWrapperDTO Get(int id)
        {
            return AwardService.GetAward(id);
        }

        // POST api/<AwardController>
        [HttpPost("MovieAward")]
        public AwardDTO AddMovieAward(MovieAwardDTO Award)
        {
            return AwardService.AddAward(Award);
        }


        [HttpPost("RoleAward")]
        public AwardDTO AddRoleAward(RoleAwardDTO Award)
        {
            return AwardService.AddAward(Award);
        }

        [HttpPost("ProducingAward")]
        public AwardDTO AddProducingAward(ProducerAwardDTO Award)
        {
            return AwardService.AddAward(Award);
        }

        // PUT api/<AwardController>/5
        [HttpPut("{id}")]
        public AwardDTO Put(AwardDTO Award)
        {
            return AwardService.UpdateAward(Award);
        }

        // DELETE api/<AwardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AwardService.DeleteAward(id);
        }
    }
}
