using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class FestivalDTO
    {

        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Photo { get; set; }

        public List<HoldingDTO> Holdings { get; set; }

        public FestivalDTO(Festival festival)
        {
            ID = festival.ID;
            Name = festival.Name;
            Description = festival.Description;
            Photo = festival.Photo;
            Holdings = new List<HoldingDTO>();
            if(festival.Holdings != null)
                foreach(var h in festival.Holdings)
                {
                    Holdings.Add(new HoldingDTO(h));
                }
        }

        public FestivalDTO()
        {
        }
    }
}
