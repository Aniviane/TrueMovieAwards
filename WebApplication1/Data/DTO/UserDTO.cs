using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class UserDTO
    {
        public long ID { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string EMail { get; set; }
        public string UType { get; set; }
        public string UPhoto { get; set; }

        public string Bio { get; set; }

        public List<PartialActorDTO> FavActors { get; set; }
        public List<PartialProducerDTO> FavProducers { get; set; }
        public List<PartialMovieDTO> FavMovies { get; set; }
        public List<UpReviewDTO> Reviews { get; set; }

        public List<NotifyDTO> Notifies { get; set; }

        public WatchListDTO? WatchList { get; set; }

        public UserDTO(User user)
        {
            ID = user.ID;
            Username = user.Username;
            FName = user.FName;
            LName = user.LName;
            Password = user.Password;
            Token = "";
            EMail = user.EMail;
            UType = user.UType;
            UPhoto = user.UPhoto;
            Bio = user.Bio;
            if (user.WatchList != null)
                WatchList = new WatchListDTO(user.WatchList);
            else
                WatchList = null;

            FavActors = new List<PartialActorDTO>();
            if(user.FavActors != null)
                foreach(var a in user.FavActors)
                {
                    FavActors.Add(new PartialActorDTO(a));
                }
            FavMovies = new List<PartialMovieDTO>();
            if(user.FavMovies != null)
                foreach (var m in user.FavMovies)
                {
                    FavMovies.Add(new PartialMovieDTO(m));
                }
            FavProducers = new List<PartialProducerDTO>();
            if (user.FavProducers != null)
                foreach (var p in user.FavProducers)
                {
                    FavProducers.Add(new PartialProducerDTO(p));
                }

            Reviews = new List<UpReviewDTO>();
            if (user.Reviews != null)
                foreach (var r in user.Reviews)
                {
                    Reviews.Add(new UpReviewDTO(r));
                }

            Notifies = new List<NotifyDTO>();
            if (user.Notifies != null)
                foreach (var n in user.Notifies)
                {
                    Notifies.Add(new NotifyDTO(n));
                }
        }

        public UserDTO()
        {
        }
    }
}
