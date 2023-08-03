using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IProducer
    {
        public ProducerDTO AddProducer(ProducerDTO Producer);

        public List<ProducerDTO> GetProducers();

        public ProducerDTO GetProducer(long id);

        public ProducerDTO UpdateProducer(ProducerDTO Producer);

        public void DeleteProducer(long id);
    }
}
