using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class HoldingDTO
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public string City { get; set; }

        public int Year { get; set; }

        public long FestivalId { get; set; }


        public List<RoleAwardDTO> RoleAwards { get; set; }

        public List<MovieAwardDTO> MovieAwards { get; set; }
        public List<ProducerAwardDTO> ProducerAwards { get; set; }

        public HoldingDTO(Holding holding)
        {
            ID = holding.ID;
            Name = holding.Name;
            City = holding.City;
            Year = holding.Year;
            FestivalId = holding.FestivalId;
            RoleAwards = new List<RoleAwardDTO>();
            MovieAwards = new List<MovieAwardDTO>();
            ProducerAwards = new List<ProducerAwardDTO>();
            if (holding.Awards != null)
                foreach(var a in holding.Awards)
                {
                    if (a.AwardType == "Movie")
                        MovieAwards.Add(new MovieAwardDTO((MovieAward)a));
                    if (a.AwardType == "Producer")
                        ProducerAwards.Add(new ProducerAwardDTO((ProducerAward)a));
                    if (a.AwardType == "Role")
                        RoleAwards.Add(new RoleAwardDTO((RoleAward)a));
                }
        }

        public HoldingDTO()
        {
        }
    }
}
