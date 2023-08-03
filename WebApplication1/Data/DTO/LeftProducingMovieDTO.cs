using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class LeftProducingMovieDTO
    {
        public PartialProducerDTO Producer { get; set; }
        public List<PartialAwardDTO> ProducingAwards { get; set; }


        public LeftProducingMovieDTO(ProducingMovie producingMovie)
        {
            Producer = new PartialProducerDTO(producingMovie.Producer);
            ProducingAwards = new List<PartialAwardDTO>();
            if(producingMovie.ProducerAwards != null)
                foreach(var pa in producingMovie.ProducerAwards)
                {
                    ProducingAwards.Add(new PartialAwardDTO(pa));
                }
        }

        public LeftProducingMovieDTO()
        {
        }
    }
}
