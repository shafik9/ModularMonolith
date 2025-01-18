namespace PresentationLayer.Dtos;

public class SlotDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid DoctorId { get; set; }
    public string? DoctorName { get; set; }
    public decimal Cost { get; set; }
}