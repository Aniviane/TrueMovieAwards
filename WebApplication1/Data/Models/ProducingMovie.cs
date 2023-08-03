using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class ProducingMovie
    {
        public virtual Producer Producer { get; set; }
        public long ProducerId { get; set; }

        public virtual Movie Movie { get; set; }
        public long MovieId { get; set; }


        public virtual List<ProducerAward> ProducerAwards { get; set; }

        public ProducingMovie() { }

        public ProducingMovie(DownProducingMovieDTO downProducingMovieDTO)
        {
            ProducerId = downProducingMovieDTO.Producer.ID;
            MovieId = downProducingMovieDTO.Movie.ID;
        }
    }
}
