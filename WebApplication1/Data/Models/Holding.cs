using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class Holding
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public string City { get; set; }

        public int Year { get; set; }
        public virtual Festival Festival { get; set; }

        public long FestivalId { get; set; }

        public virtual List<Award> Awards { get; set; }
        public Holding() { }

        public Holding(HoldingDTO holdingDTO)
        {
            City = holdingDTO.City;
            Name = holdingDTO.Name;
            Year = holdingDTO.Year;

            Awards = new List<Award>();

        }
    }
}
