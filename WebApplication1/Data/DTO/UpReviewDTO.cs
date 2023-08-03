using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class UpReviewDTO
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public int Grade { get; set; }

        public DateTime RevTime { get; set; }

        public PartialMovieDTO Movie { get; set; }

        public UpReviewDTO(Review review)
        {
            ID = review.ID;
            Description = review.Description;
            Grade = review.Grade;
            RevTime = review.RevTime;
            Movie = new PartialMovieDTO(review.Movie);
        }

        public UpReviewDTO()
        {
        }
    }
}
