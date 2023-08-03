using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class PartialUserDTO
    {
        public long ID { get; set; }
        public string Username { get; set; }

        public string UPhoto { get; set; }

        public PartialUserDTO(User user)
        {
            ID = user.ID;
            Username = user.Username;
            UPhoto = user.UPhoto;
        }

        public PartialUserDTO()
        {
        }
    } 
}
