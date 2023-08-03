using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;

namespace WebApplication1.Controllers.Services
{
    public class ActorService : IActor
    {
        private DataContext context;

        public ActorService(DataContext dataContext)
        {
            context = dataContext;
        }
        public ActorDTO AddActor(ActorDTO actor)
        {
            var a = new Actor(actor);

            context.Actors.Add(a);

            context.SaveChanges();

            return new ActorDTO(a);
           
            
        }


      

        public void DeleteActor(long id)
        {
            var a = context.Actors.Find(id);
            if (a != null)
            {
                context.Actors.Remove(a);
                context.SaveChanges();
            }

        }

        public ActorDTO GetActor(long id)
        {
            var a = context.Actors.Find(id);
            if(a != null)
            return new ActorDTO(a);
            else 
                return null;
        }

        public List<ActorDTO> GetActors()
        {
            var actors = context.Actors.ToList<Actor>();
            var ret = new List<ActorDTO>();
            if(actors != null)
            foreach(var a in actors)
                {
                    ret.Add(new ActorDTO(a));
                }

            return ret;
        }

        public ActorDTO UpdateActor(ActorDTO actor)
        {
            var ac = context.Actors.Find(actor.ID);
            if(ac != null)
            {
                ac.FName = actor.FName;
                ac.LName = actor.LName;
                ac.Bio = actor.Bio;
                ac.APhoto = actor.APhoto;

                context.Entry(ac).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                context.SaveChanges();

                return new ActorDTO(ac);
            }

            return null;

        }
    }
}
