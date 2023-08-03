using System.Xml.Linq;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class StudioDTO
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public List<PartialMovieDTO> Movies { get; set; }

        public StudioDTO(Studio studio)
        {
            ID = studio.ID;
            Name = studio.Name;
            Description = studio.Description;
            Photo = studio.Photo;
            Movies = new List<PartialMovieDTO>();
            if(studio.Movies  != null)
                foreach (var m in studio.Movies)
                {
                    Movies.Add(new PartialMovieDTO(m));
                }
        }

        public StudioDTO()
        {
        }
    }
}
