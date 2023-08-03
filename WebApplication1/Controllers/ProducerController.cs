using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {

        public IProducer producerService;

        public ProducerController(IProducer producer)
        {
            producerService = producer;
        }
        // GET: api/<ProducerController>
        [HttpGet]
        public IEnumerable<ProducerDTO> Get()
        {
             var ret = producerService.GetProducers();
            return ret;
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public ProducerDTO Get(int id)
        {
            return producerService.GetProducer(id);
        }

        // POST api/<ProducerController>
        [HttpPost]
        public ProducerDTO Post(ProducerDTO producer)
        {
            return producerService.AddProducer(producer);
        }

        // PUT api/<ProducerController>/5
        [HttpPut("{id}")]
        public ProducerDTO Put(ProducerDTO producer)
        {
            return producerService.UpdateProducer(producer);
        }

        // DELETE api/<ProducerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            producerService.DeleteProducer(id);
        }
    }
}
