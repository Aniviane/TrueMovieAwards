namespace WebApplication1.Data.Models
{
    public class Notification
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public DateTime DateOfNotification { get; set; }

        public virtual Award Award { get; set; }

        public long AwardId { get; set; }

        public virtual List<Notify> Notifies { get; set; }

        public Notification() { }

    }
}
