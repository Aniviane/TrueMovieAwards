using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface ISeries
    {
        public SeriesDTO AddSeries(SeriesDTO series);

        public List<SeriesDTO> GetSeries();

        public SeriesDTO GetSeries(long id);

        public SeriesDTO UpdateSeries(SeriesDTO series);

        public void DeleteSeries(long id);

        public SeriesDTO AddMovie(SeriesDTO series);
    }
}
