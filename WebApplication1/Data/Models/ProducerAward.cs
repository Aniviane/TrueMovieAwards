using System.Data;
using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class ProducerAward : Award
    {
        public virtual List<ProducingMovie> Producings { get; set; }

        public ProducerAward() : base() { }

        public ProducerAward(ProducerAwardDTO awardDTO) : base(awardDTO)
        {
            Producings = new List<ProducingMovie>();
            foreach (var pr in awardDTO.Producings)
            {
                Producings.Add(new ProducingMovie(pr));
            }
        }

    }
}
