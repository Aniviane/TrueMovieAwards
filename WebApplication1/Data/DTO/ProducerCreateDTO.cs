namespace WebApplication1.Data.DTO
{
    public class ProducerCreateDTO
    {
        
        public string FName { get; set; }
        public string LName { get; set; }

        public string DoB { get; set; }
        public IFormFile Photo { get; set; }

        public string Bio { get; set; }
    }
}
