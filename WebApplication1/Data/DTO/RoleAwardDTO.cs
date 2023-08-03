using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class RoleAwardDTO : AwardDTO
    {
        public List<DownRoleDTO> Roles { get; set; }

        public RoleAwardDTO(RoleAward award) : base(award)
        {
            Roles = new List<DownRoleDTO>();
            if(award.Roles != null)
                foreach (var r in award.Roles)
                {
                    Roles.Add(new DownRoleDTO(r));
                }
        }

        public RoleAwardDTO()
        {
        }
    }
}
