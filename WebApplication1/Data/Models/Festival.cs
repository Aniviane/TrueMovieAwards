using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class Festival
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Photo { get; set; }

        public virtual List<Holding> Holdings { get; set; }

        public Festival() { }

        public Festival(FestivalDTO festivalDTO)
        {
            Name = festivalDTO.Name;
            Description = festivalDTO.Description;
            Photo = festivalDTO.Photo;
            Holdings = new List<Holding>(); 
        }

        public Festival(FestivalCreateDTO dto)
        {
            Name = dto.Name;
            Description = dto.Description;
            Holdings = new List<Holding>();
            Photo = "";

        }
    }
}
