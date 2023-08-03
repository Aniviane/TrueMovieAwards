using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class Studio
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public virtual List<Movie> Movies { get; set; }

        public Studio() { }

        public Studio(StudioDTO studio)
        {
            Name = studio.Name;
            Description = studio.Description;
            Photo = studio.Photo;
            Movies = new List<Movie>();
           
        }
    }
}
