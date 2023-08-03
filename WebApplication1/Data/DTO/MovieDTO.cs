using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class MovieDTO
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime DateOfRelease { get; set; }
        public string Photo { get; set; }

        public float RevGrade { get; set; }
        public int RevCount { get; set; }

        public List<LeftProducingMovieDTO> Producings { get; set; }
        public List<RightRoleDTO> Roles { get; set; }

        public List<PartialAwardDTO> MovieAwards { get; set; }

        public PartialSeriesDTO? Series { get; set; }

        public PartialStudioDTO? Studio { get; set; }

        public List<PartialGenreDTO> Genres { get; set; }
        public List<DownReviewDTO> Reviews { get; set; }


        public MovieDTO(Movie movie)
        {
            ID = movie.ID;
            Title = movie.Title;
            Description = movie.Description;
            DateOfRelease = movie.DateOfRelease;
            Photo = movie.Photo;
            RevCount = movie.RevCount;
            RevGrade = movie.RevGrade;
            Producings = new List<LeftProducingMovieDTO>();
            if (movie.Producings != null)
                foreach(var pr in movie.Producings)
                {
                    Producings.Add(new LeftProducingMovieDTO(pr));
                }
            Roles = new List<RightRoleDTO>();
            if(movie.Roles != null) 
                foreach (var r in movie.Roles)
                {
                    Roles.Add(new RightRoleDTO(r));
                }
            MovieAwards = new List<PartialAwardDTO>();
            if(movie.MovieAwards != null)
                foreach (var ma in movie.MovieAwards)
                {   
                    MovieAwards.Add(new PartialAwardDTO(ma));
                }
            if(movie.Series != null)
                Series = new PartialSeriesDTO(movie.Series);

            if (movie.Studio != null)
                Studio = new PartialStudioDTO(movie.Studio);

            Genres = new List<PartialGenreDTO>();
            if( movie.Genres != null)
                foreach(var g in movie.Genres)
                {
                    Genres.Add(new PartialGenreDTO(g));
                }
            Reviews = new List<DownReviewDTO>();
            if(movie.Reviews != null)
                foreach(var r in movie.Reviews)
                {
                    Reviews.Add(new DownReviewDTO(r));
                }

        }

        public MovieDTO()
        {
        }
    }
}
