using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class LeftRoleDTO
    {
        public long ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public PartialMovieDTO Movie { get; set; }
        public List<PartialAwardDTO> RoleAwards { get; set; }


        public LeftRoleDTO(Role role)
        {
            ID = role.ID;
            FName = role.FName;
            LName = role.LName;
            Movie = new PartialMovieDTO(role.Movie);
            RoleAwards = new List<PartialAwardDTO>();
            if(role.RoleAwards != null)
                foreach(var ra in role.RoleAwards)
                {
                    RoleAwards.Add(new PartialAwardDTO(ra));
                }
        }

        public LeftRoleDTO()
        {
        }
    }
}
