using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class DownRoleDTO
    {
        public long ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public PartialActorDTO Actor { get; set; }

        public PartialMovieDTO Movie { get; set; }

        public DownRoleDTO(Role role)
        {
            ID = role.ID;
            FName = role.FName;
            LName = role.LName;
            Movie = new PartialMovieDTO(role.Movie);
            Actor = new PartialActorDTO(role.Actor); 
        }

        public DownRoleDTO()
        {
        }
    }
}
