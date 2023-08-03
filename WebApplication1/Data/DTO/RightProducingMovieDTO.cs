using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class RightProducingMovieDTO
    {
        public long ID { get; set; }
        public PartialMovieDTO Movie { get; set; }
        public List<PartialAwardDTO> ProducingAwards { get; set; }


        public RightProducingMovieDTO(ProducingMovie producingMovie)
        {
            Movie = new PartialMovieDTO(producingMovie.Movie);
            ProducingAwards = new List<PartialAwardDTO>();
            if(producingMovie.ProducerAwards != null)
                foreach (var pa in producingMovie.ProducerAwards)
                {
                    ProducingAwards.Add(new PartialAwardDTO(pa));
                }
        }

        public RightProducingMovieDTO()
        {
        }
    }
}
