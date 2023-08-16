using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IStudio
    {
        public StudioDTO AddStudio(StudioCreateDTO studio);

        public List<StudioDTO> GetStudios();

        public StudioDTO GetStudio(long id);

        public StudioDTO UpdateStudio(StudioDTO studio);

        public void DeleteStudio(long id);

        public StudioDTO AddMovie(StudioDTO studio);
    }
}
