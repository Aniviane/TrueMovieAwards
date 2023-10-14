using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase

    {


        public IActor actorService;

        public ActorController(IActor _actorService)
        {
            actorService = _actorService;
        }


        // GET: api/<ActorController>
        [HttpGet]
        public  ActionResult<IEnumerable<ActorDTO>> Get()
        {

            var ret = actorService.GetActors();

            
          
            return Ok(ret);
        }

       


        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public ActorDTO Get(int id)
        {


            return actorService.GetActor(id);
        }

        // POST api/<ActorController>
        [HttpPost]
        public  ActorDTO  Post([FromForm] ActorCreateDTO actorDTO)
        {
           
            var newActor = actorService.AddActor(actorDTO);


            return newActor;
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public ActorDTO Put(ActorDTO actor)
        {
            return actorService.UpdateActor(actor);
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            actorService.DeleteActor(id);
        }

        [HttpPut("UpdatePhoto")]
        public void updatePhoto([FromForm] PhotoUpdateDTO dto)
        {
            actorService.UpdatePhoto(dto);
        }
    }
}
