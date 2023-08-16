using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class AwardWrapperDTO
    {
        public string AwardType { get; set; }

        public RoleAwardDTO RoleAward{ get; set; }
        public MovieAwardDTO MovieAward { get; set; }

        public ProducerAwardDTO ProducerAward { get; set; }

        public AwardWrapperDTO(AwardDTO award)
        {
            AwardType = award.AwardType;
            if (AwardType == "Role")
            RoleAward = (RoleAwardDTO)award;
            if (AwardType == "Producer")
                ProducerAward = (ProducerAwardDTO)award;
            if (AwardType == "Movie")
                MovieAward = (MovieAwardDTO)award;
        }

        public AwardWrapperDTO(Award award)
        {
            AwardType = award.AwardType;
            if (AwardType == "Role")
                RoleAward = new RoleAwardDTO((RoleAward)award);
            if (AwardType == "Producer")
                ProducerAward = new ProducerAwardDTO((ProducerAward)award);
            if (AwardType == "Movie")
                MovieAward = new MovieAwardDTO((MovieAward)award);
        }
    }
}
