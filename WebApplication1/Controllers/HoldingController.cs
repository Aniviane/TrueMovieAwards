using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoldingController : ControllerBase
    {
        public IHolding HoldingService;

        public HoldingController(IHolding Holding)
        {
            HoldingService = Holding;
        }
        // GET: api/<HoldingController>
        [HttpGet]
        public IEnumerable<HoldingDTO> Get()
        {
            var ret = HoldingService.GetHoldings();
            return ret;
        }

        // GET api/<HoldingController>/5
        [HttpGet("{id}")]
        public HoldingDTO Get(int id)
        {
            return HoldingService.GetHolding(id);
        }

        // POST api/<HoldingController>
        [HttpPost]
        public HoldingDTO Post(HoldingDTO Holding)
        {
            return HoldingService.AddHolding(Holding);
        }

        // PUT api/<HoldingController>/5
        [HttpPut("{id}")]
        public HoldingDTO Put(HoldingDTO Holding)
        {
            return HoldingService.UpdateHolding(Holding);
        }

        // DELETE api/<HoldingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            HoldingService.DeleteHolding(id);
        }
    }
}
