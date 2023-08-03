using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class DownReviewDTO
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public int Grade { get; set; }

        public DateTime RevTime { get; set; }


        public PartialUserDTO Reviewer { get; set; }

        public DownReviewDTO(Review review)
        {
            ID = review.ID;
            Description = review.Description;
            Grade = review.Grade;
            RevTime = review.RevTime;
            Reviewer = new PartialUserDTO(review.Reviewer);
        }

        public DownReviewDTO()
        {
        }
    }
}
