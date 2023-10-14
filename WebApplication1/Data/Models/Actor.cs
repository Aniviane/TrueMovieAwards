using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class Actor
    {
        public long ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
     
        public DateTime DoB { get; set; }
        public string APhoto { get; set; }

        public string Bio { get; set; }

        public virtual List<Role> Roles { get; set; }

        public virtual List<User> Favorites { get; set; }


        public Actor() { }

        public Actor(ActorDTO actor)
        {
            APhoto = actor.APhoto;
            Bio = actor.Bio;
            DoB = actor.DoB;
            LName = actor.LName;
            FName = actor.FName;
            Roles = new List<Role>();
            Favorites = new List<User>();
        }


        public Actor(ActorCreateDTO dto)
        {
            Bio = dto.Bio;
            DoB = DateTime.Parse(dto.DoB);
            LName = dto.LName;
            FName = dto.FName;
            Roles = new List<Role>();
            Favorites = new List<User>();
            APhoto = "";
        }
    }
}
