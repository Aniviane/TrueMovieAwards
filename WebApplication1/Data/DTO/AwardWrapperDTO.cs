using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class AwardWrapperDTO
    {
        public string AwardType { get; set; }

        public AwardDTO AwardData { get; set; }

        public AwardWrapperDTO(AwardDTO award)
        {
            AwardType = award.AwardType;
            AwardData = award;
        }

        public AwardWrapperDTO(Award award)
        {
            AwardType = award.AwardType;
            AwardData = new AwardDTO(award);
        }
    }
}
