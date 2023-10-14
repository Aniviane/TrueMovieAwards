using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IActor
    {
        public ActorDTO AddActor(ActorCreateDTO actor);

        public List<ActorDTO> GetActors();

        public ActorDTO GetActor(long id);

        public void UpdatePhoto(PhotoUpdateDTO photoUpdateDTO);

        public ActorDTO UpdateActor(ActorDTO actor);

        public void DeleteActor(long id);
    }
}
