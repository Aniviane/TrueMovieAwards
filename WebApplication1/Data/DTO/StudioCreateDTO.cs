namespace WebApplication1.Data.DTO
{
    public class StudioCreateDTO
    {
        public string name { get; set; }

        public string description { get; set; }

        public IFormFile photo { get; set; }
    }
}
