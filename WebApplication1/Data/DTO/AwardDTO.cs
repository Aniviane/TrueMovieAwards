using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class AwardDTO
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public string AwardType { get; set; }
        public long FestivalId { get; set; }

        public long HoldingId { get; set; }

       

        public AwardDTO(Award award)
        {
            ID = award.ID;
            Name = award.Name;
            AwardType = award.AwardType;
            FestivalId = award.Holding.FestivalId;
            HoldingId = award.HoldingId;
        }

        public AwardDTO()
        {
        }
    }
}
