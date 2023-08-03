using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class PartialSeriesDTO
    {
        public long ID { get; set; }
        public string FName { get; set; }

        public PartialSeriesDTO(Series series)
        {
            if (series != null)
            {
                ID = series.ID;
                FName = series.FName;
            }
 

        }

        public PartialSeriesDTO()
        {
        }
    }
}
