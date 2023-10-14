namespace WebApplication1.Data.DTO
{
    public class ActorCreateDTO
    {
       
        public string FName { get; set; }
        public string LName { get; set; }

        public string DoB { get; set; }
        public IFormFile APhoto { get; set; }

        public string Bio { get; set; }
    }
}
