using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class ActorDTO
    {
        public long ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public DateTime DoB { get; set; }
        public string APhoto { get; set; }

        public string Bio { get; set; }

        public List<LeftRoleDTO> Roles { get; set; }

        public ActorDTO(Actor actor)
        {
            ID = actor.ID;
            FName = actor.FName;
            LName = actor.LName;
            DoB = actor.DoB;
            APhoto = actor.APhoto;
            Bio = actor.Bio;
            Roles = new List<LeftRoleDTO>();
            if(actor.Roles != null)
                foreach(var r in actor.Roles)
                {
                    Roles.Add(new LeftRoleDTO(r));
                }
        }

        public ActorDTO()
        {
        }
    }
}
