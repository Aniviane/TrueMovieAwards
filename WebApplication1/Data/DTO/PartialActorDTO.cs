using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class PartialActorDTO
    {

        public long ID { get; set; }
        public string Photo { get; set; }

        public string Fname { get; set; }
        public string Lname { get; set; }

        public PartialActorDTO(Actor actor)
        {
            ID = actor.ID;
            Photo = actor.APhoto;
            Fname = actor.FName;
            Lname = actor.LName;

        }

        public PartialActorDTO()
        {
        }
    }
}
