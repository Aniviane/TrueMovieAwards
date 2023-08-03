using System.Net.Http.Headers;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class ProducerDTO
    {
        public long ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public DateTime DoB { get; set; }
        public string Photo { get; set; }

        public string Bio { get; set; }

        public List<RightProducingMovieDTO> Producings { get; set; }

        public ProducerDTO(Producer producer)
        {
            ID = producer.ID;
            FName = producer.FName;
            LName = producer.LName;
            DoB = producer.DoB;
            Photo = producer.Photo;
            Bio = producer.Bio;
            Producings = new List<RightProducingMovieDTO>();
            if(producer.Producings != null)
                foreach (var p in producer.Producings)
                {
                    Producings.Add(new RightProducingMovieDTO(p));
                }
        }

        public ProducerDTO()
        {
        }
    }
}
