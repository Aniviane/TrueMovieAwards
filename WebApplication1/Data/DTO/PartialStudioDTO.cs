using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class PartialStudioDTO
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public PartialStudioDTO(Studio studio)
        {
            ID = studio.ID;
            Name = studio.Name;
            Description = studio.Description;
            Photo = studio.Photo;

        }

        public PartialStudioDTO()
        {
        }
    }
}
