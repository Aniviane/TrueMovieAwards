using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IUser
    {
        public UserDTO Register(UserCreateDTO user);

        public List<UserDTO> GetUsers();

        public UserDTO Login(UserLoginDTO userDTO);

        public UserDTO GetUser(long id);

        public void UpdatePhoto(PhotoUpdateDTO photoUpdateDTO);
        public UserDTO UpdateUser(UserDTO User);

        public void UpdateNotify(long id);
        public UpReviewDTO LeaveReview(UpReviewDTO reviewDTO);
        public void DeleteReview(long id);

        public UpReviewDTO UpdateReview(UpReviewDTO reviewDTO);

        public void DeleteUser(long id);

        public void FavSomething(FavoriseDTO favoriseDTO);

        public UserDTO RegisterModerator(UserLoginDTO dto);

        public WatchListDTO AddToWatchlist(long movieId);
    }
}
