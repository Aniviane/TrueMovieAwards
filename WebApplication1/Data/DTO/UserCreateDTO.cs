namespace WebApplication1.Data.DTO
{
    public class UserCreateDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string EMail { get; set; }
        public string UType { get; set; }
        public IFormFile UPhoto { get; set; }

        public string Bio { get; set; }
    }
}
