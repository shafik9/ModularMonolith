using CSharpFunctionalExtensions;
using Notifications.Dtos;

namespace Notifications.Models;

public class AppointmentConfirmation
{
    private AppointmentConfirmation()
    {
        
    }
    public int DoctorId { get; private set; }
    public int PatientId { get; private set; }
    public int SlotId { get; private set; }
    public string? PatientName { get; private set; }
    public string? DoctorName { get; private set; }
    public DateTime ReservationDate { get; private set; }

    public static AppointmentConfirmation Create
    (
        AddConfirmationDto addConfirmationDto
    )
    {
        return new AppointmentConfirmation
        {
            DoctorId = addConfirmationDto.DoctorId,
            PatientId = addConfirmationDto.PatientId,
            SlotId = addConfirmationDto.SlotId,
            PatientName = addConfirmationDto.PatientName,
            DoctorName = addConfirmationDto.DoctorName,
            ReservationDate = addConfirmationDto.ReservationDate,
        };
    }
}