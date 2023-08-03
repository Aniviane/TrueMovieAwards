using WebApplication1.Data.DTO;

namespace WebApplication1.Data.Models
{
    public class Review
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public int Grade { get; set; }

        public DateTime RevTime { get; set; }


        public virtual User Reviewer { get; set; }
  

        public long UserId { get; set; }
        public virtual Movie Movie { get; set; }

        public long MovieId { get; set; }

        public Review() { }


        public Review(UpReviewDTO reviewDTO)
        {
            Description = reviewDTO.Description;
            Grade = reviewDTO.Grade;
            RevTime = DateTime.Now;
            MovieId = reviewDTO.Movie.ID;

        }

    }
}
