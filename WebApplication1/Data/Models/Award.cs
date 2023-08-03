using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class Award
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public virtual Holding Holding { get; set; }

        public string AwardType { get; set; }

        public long HoldingId { get; set; }

        public virtual Notification Notification { get; set; }

        public Award() { }

        public Award(AwardDTO awardDTO)
        {
            Name = awardDTO.Name;
            HoldingId = awardDTO.HoldingId;
            AwardType = awardDTO.AwardType;

        } 

    }
}
