using System.Linq.Expressions;
using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class User
    {
        public long ID { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string EMail { get; set; }
        public string UType { get; set; }
        public string UPhoto { get; set; }

        public string Bio { get; set; }

        public virtual List<Actor> FavActors { get; set; }
        public virtual List<Producer> FavProducers { get; set; }
        public virtual List<Movie> FavMovies { get; set; }
        public virtual List<Review> Reviews { get; set; }

        public virtual User? Admin { get; set; }

        public long? AdminId { get; set; }

        public virtual List<User> CreatedModerators { get; set; }

        public virtual List<Notify> Notifies { get; set; }

        public virtual WatchList WatchList { get; set; }

        public User() { }

        public User(UserDTO user)
        {
            Username = user.Username;
            Password = user.Password;
            EMail = user.EMail;
            UType = user.UType;
            UPhoto = user.UPhoto;
            FName = user.FName;
            LName = user.LName;
            Bio = user.Bio;
            FavActors = new List<Actor>();
            FavProducers = new List<Producer>();
            FavMovies = new List<Movie>();
            Reviews = new List<Review>();
            WatchList = new WatchList();
        }

        public User(UserCreateDTO user)
        {
            Username = user.Username;
            Password = user.Password;
            EMail = user.EMail;
            UType = user.UType;
            UPhoto = "";
            FName = user.FName;
            LName = user.LName;
            Bio = user.Bio;
            FavActors = new List<Actor>();
            FavProducers = new List<Producer>();
            FavMovies = new List<Movie>();
            Reviews = new List<Review>();
            WatchList = new WatchList();
        }



    }
}
