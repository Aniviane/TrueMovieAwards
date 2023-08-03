using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTO
{
    public class NotifyDTO
    {


        public bool Seen { get; set; }

        public string description { get; set; }

        public long AwardId { get; set; }


        public NotifyDTO(Notify notify)
        {
            Seen = notify.Seen;
            description = notify.Notification.Description;
            AwardId = notify.Notification.AwardId;
        }

        public NotifyDTO()
        {
        }
    }
}
