using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class DownProducingMovieDTO  
    {
        public long ID { get; set; }
        public PartialProducerDTO Producer { get; set; }

        public PartialMovieDTO Movie { get; set; }

        public DownProducingMovieDTO(ProducingMovie producingMovie)
        {
            Producer = new PartialProducerDTO(producingMovie.Producer);
            Movie = new PartialMovieDTO(producingMovie.Movie);
        }

        public DownProducingMovieDTO()
        {
        }
    }
}
