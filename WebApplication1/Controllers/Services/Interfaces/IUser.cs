using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IUser
    {
        public UserDTO Register(UserDTO user);

        public List<UserDTO> GetUsers();

        public UserDTO Login(UserLoginDTO userDTO);

        public UserDTO GetUser(long id);

        public UserDTO UpdateUser(UserDTO User);

        public void UpdateNotify(long id);
        public UpReviewDTO LeaveReview(UpReviewDTO reviewDTO);

        public void DeleteUser(long id);

        public void FavSomething(FavoriseDTO favoriseDTO);
    }
}
