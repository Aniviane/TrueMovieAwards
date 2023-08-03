namespace WebApplication1.Data.Models
{
    public class Notify
    {
      

        public long NotificationId { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }

        public bool Seen { get; set; }
        public virtual Notification Notification { get; set;}

        public Notify() { }
    }
}
