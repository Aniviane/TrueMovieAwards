using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IProducer
    {
        public ProducerDTO AddProducer(ProducerCreateDTO Producer);

        public List<ProducerDTO> GetProducers();

        public void UpdatePhoto(PhotoUpdateDTO photoUpdateDTO);
        public ProducerDTO GetProducer(long id);

        public ProducerDTO UpdateProducer(ProducerDTO Producer);

        public void DeleteProducer(long id);
    }
}
