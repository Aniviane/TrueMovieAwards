using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IFestival
    {

        public FestivalDTO AddFestival(FestivalDTO Festival);

        public List<FestivalDTO> GetFestivals();

       

        public FestivalDTO GetFestival(long id);

        public FestivalDTO UpdateFestival(FestivalDTO Festival);

        public void DeleteFestival(long id);

        


    }
}
