using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IActor
    {
        public ActorDTO AddActor(ActorDTO actor);

        public List<ActorDTO> GetActors();

        public ActorDTO GetActor(long id);

        public ActorDTO UpdateActor(ActorDTO actor);

        public void DeleteActor(long id);
    }
}
