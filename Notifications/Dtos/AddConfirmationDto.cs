namespace Notifications.Dtos;

public class AddConfirmationDto
{
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public int SlotId { get; set; }
    public string? PatientName { get; set; }
    public string? DoctorName { get; set; }
    public DateTime ReservationDate { get; set; }
}