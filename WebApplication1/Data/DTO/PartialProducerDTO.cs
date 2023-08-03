using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class PartialProducerDTO
    {
        public long ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public string Photo { get; set; }

        public PartialProducerDTO(Producer producer)
        {
            ID = producer.ID;
            FName = producer.FName;
            LName = producer.LName;
            Photo = producer.Photo;
        }

        public PartialProducerDTO()
        {
        }
    }
}
