namespace WebApplication1.Data.Models
{
    public class Genre
    {
        public long ID { get; set; }
        public string FName { get; set; }

        public virtual List<Movie> Movies { get; set; }


        public Genre() { }
    }
}
