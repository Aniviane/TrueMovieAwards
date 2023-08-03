using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class PartialGenreDTO
    {

        public long ID { get; set; }
        public string FName { get; set; }


        public PartialGenreDTO(Genre genre)
        {
            ID = genre.ID;
            FName = genre.FName;

        }

        public PartialGenreDTO()
        {
        }
    }
}
