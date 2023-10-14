using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class Producer
    {
        public long ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public DateTime DoB { get; set; }
        public string Photo { get; set; }

        public string Bio { get; set; }

        public virtual List<ProducingMovie> Producings { get; set; }

        public virtual List<User> Favorites { get; set; }

        public Producer() { }
        public Producer(ProducerDTO producerDTO) {

            FName = producerDTO.FName;
            LName = producerDTO.LName;
            Photo = producerDTO.Photo;
            DoB = producerDTO.DoB;
            Bio = producerDTO.Bio;
            Producings = new List<ProducingMovie>();
            Favorites = new List<User>();

        
        }


        public Producer(ProducerCreateDTO producerDTO)
        {

            FName = producerDTO.FName;
            LName = producerDTO.LName;
            Photo = "";
            DoB = DateTime.Parse(producerDTO.DoB);
            Bio = producerDTO.Bio;
            Producings = new List<ProducingMovie>();
            Favorites = new List<User>();


        }
    }
}
