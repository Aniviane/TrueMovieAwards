using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class RoleAward : Award
    {
        public virtual List<Role> Roles { get; set; }

        public RoleAward() : base() { }

        public RoleAward(RoleAwardDTO awardDTO) : base(awardDTO)
        {
            Roles = new List<Role>();
            foreach(var r in awardDTO.Roles)
            {
                Roles.Add(new Role(r));
            }
        }
    }
}
