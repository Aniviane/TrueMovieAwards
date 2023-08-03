using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class PartialAwardDTO
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public PartialAwardDTO(Award award)
        {
            ID = award.ID;
            Name = award.Name;
        }

        public PartialAwardDTO()
        {
        }
    }
}
