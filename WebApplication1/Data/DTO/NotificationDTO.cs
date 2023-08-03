using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class NotificationDTO
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public DateTime DateOfNotification { get; set; }

        public PartialAwardDTO Award { get; set; }

        public NotificationDTO(Notification notification)
        {
            ID = notification.ID;
            Description = notification.Description;
            DateOfNotification = notification.DateOfNotification;
            Award = new PartialAwardDTO(notification.Award);

        }

        public NotificationDTO()
        {
        }
    }
}
