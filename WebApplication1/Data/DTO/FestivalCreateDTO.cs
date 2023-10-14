namespace WebApplication1.Data.DTO
{
    public class FestivalCreateDTO
    {
       
        public string Name { get; set; }
        public string Description { get; set; }

        public IFormFile Photo { get; set; }
    }
}
