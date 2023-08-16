using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IAward
    {
        public AwardDTO AddAward(AwardDTO Award);

        public List<AwardWrapperDTO> GetAwards();

        public AwardWrapperDTO GetAward(long id);

        public AwardDTO UpdateAward(AwardDTO Award);

        public void DeleteAward(long id);
    }
}
