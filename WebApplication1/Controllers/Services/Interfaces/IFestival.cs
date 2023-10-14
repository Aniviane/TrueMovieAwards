using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IFestival
    {

        public FestivalDTO AddFestival(FestivalCreateDTO Festival);

        public List<FestivalDTO> GetFestivals();

        public void UpdatePhoto(PhotoUpdateDTO photoUpdateDTO);

        public FestivalDTO GetFestival(long id);

        public FestivalDTO UpdateFestival(FestivalDTO Festival);

        public void DeleteFestival(long id);

        


    }
}
