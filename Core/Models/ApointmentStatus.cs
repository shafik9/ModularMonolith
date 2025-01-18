

namespace Core.Models
{
    public class AppointmentStatus
    {
        public Guid Id { get; set; }
        public Guid AppointmentId { get; set; }
        public int StatusId { get; set; }
    }
}
