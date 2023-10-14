using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class Movie
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime DateOfRelease { get; set; }
        public string Photo { get; set; }

        public float RevGrade { get; set; }
        public int RevCount { get; set; }

        public virtual List<ProducingMovie> Producings { get; set; }
        public virtual List<Role> Roles { get; set; }

        public virtual List<User> Favorites { get; set; }

        public virtual Studio Studio { get; set; }

        public long? StudioId { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual Series Series { get; set; }

        public long? SeriesId { get; set; }

        public virtual List<WatchList> WatchLists { get; set; }

        public virtual List<MovieAward> MovieAwards { get; set; }

        public Movie() { }

        public Movie(PartialMovieDTO partialMovieDTO)
        {
            ID = partialMovieDTO.ID;
            
        }


        public Movie(MovieDTO movieDTO)
        {
            Description = movieDTO.Description;
            Title = movieDTO.Title;
            DateOfRelease = movieDTO.DateOfRelease;
            Photo = movieDTO.Photo;

            RevCount = 0;
            RevGrade = 0;

            Genres = new List<Genre>();

            Roles = new List<Role>();

            Producings = new List<ProducingMovie>();

            WatchLists = new List<WatchList>();

            Favorites = new List<User>();

            MovieAwards = new List<MovieAward>();

        }



        public Movie(MovieCreateDTO movieDTO)
        {
            Description = movieDTO.Description;
            Title = movieDTO.Title;
            DateOfRelease = DateTime.Parse(movieDTO.DateOfRelease);
            Photo = "";

            RevCount = 0;
            RevGrade = 0;

            Genres = new List<Genre>();

            Roles = new List<Role>();

            Producings = new List<ProducingMovie>();

            WatchLists = new List<WatchList>();

            Favorites = new List<User>();

            MovieAwards = new List<MovieAward>();

        }

    }
}
