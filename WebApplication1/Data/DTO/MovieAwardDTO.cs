using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class MovieAwardDTO : AwardDTO
    {
         public List<PartialMovieDTO> Movies { get; set; }


       

        public MovieAwardDTO(MovieAward award) : base(award)
        {
            Movies = new List<PartialMovieDTO>();
            if(award.Movies != null)
                foreach(var m in award.Movies)
                {   
                    Movies.Add(new PartialMovieDTO(m));
                }
        }

        public MovieAwardDTO()
        {
        }
    }
}
