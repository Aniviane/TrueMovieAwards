using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class MovieAward : Award
    {
        public virtual List<Movie> Movies { get; set; }

        public MovieAward() : base() { }

        public MovieAward(MovieAwardDTO awardDTO) : base(awardDTO)
        {
            Movies = new List<Movie>();
            foreach(var m in awardDTO.Movies)
            {
                Movies.Add(new Movie(m));
            }
        }
    }
}
