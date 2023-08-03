using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class RightRoleDTO
    {
        public long ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public PartialActorDTO Actor { get; set; }
        public List<PartialAwardDTO> RoleAwards { get; set; }

        public RightRoleDTO(Role role)
        {
            ID = role.ID;
            FName = role.FName;
            LName = role.LName;
            Actor = new PartialActorDTO(role.Actor);
            RoleAwards = new List<PartialAwardDTO>();
            if(role.RoleAwards != null)
                foreach (var ra in role.RoleAwards)
                {
                    RoleAwards.Add(new PartialAwardDTO(ra));
                }
        }

        public RightRoleDTO()
        {
        }
    }
}
