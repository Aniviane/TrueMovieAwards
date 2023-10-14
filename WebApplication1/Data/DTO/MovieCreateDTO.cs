using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.DTO
{
    public class MovieCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string DateOfRelease { get; set; }
        public IFormFile Photo { get; set; }

      
        public List<RoleCreateDTO> Roles { get; set; }

        [Required(AllowEmptyStrings = true)]
        public List<string>? Producings { get; set; }

        [Required(AllowEmptyStrings = true)]
        public List<string>? Genres { get; set; }

        public string StudioId { get; set; }

        public string SeriesId { get; set; }
    }
}
