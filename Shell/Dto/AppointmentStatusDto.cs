
namespace Shell.Dto
{
    internal class AppointmentStatusDto
    {
        public Guid Id { get; set; }
        public Guid AppointmentId { get; set; }
        public int StatusId { get; set; }
    }
}
