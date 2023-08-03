using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class ProducerAwardDTO : AwardDTO
    {
        public List<DownProducingMovieDTO> Producings { get; set; }

        public ProducerAwardDTO(ProducerAward award) : base(award)
        {
            Producings = new List<DownProducingMovieDTO>();
            if(award.Producings != null)
                foreach( var p in award.Producings)
                {
                    Producings.Add(new DownProducingMovieDTO(p));
                }
        }

        public ProducerAwardDTO()
        {
        }
    }
}
