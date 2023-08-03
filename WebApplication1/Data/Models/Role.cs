using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class Role
    {
        public long ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public virtual Actor Actor { get; set; }
        
        public long ActorId { get; set; }
        public virtual Movie Movie { get; set; }

        public long MovieId { get; set; }


        public virtual List<RoleAward> RoleAwards { get; set; }

        public Role() { }

        public Role(DownRoleDTO downRoleDTO)
        {
            FName = downRoleDTO.FName;
            LName = downRoleDTO.LName;
            ActorId = downRoleDTO.Actor.ID;
            MovieId = downRoleDTO.Movie.ID;

        }
    }
}
