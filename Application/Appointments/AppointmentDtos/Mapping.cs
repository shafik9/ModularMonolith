using Domain;

namespace Application.Appointments.AppointmentDtos;

public static class Mapping
{
    public static AppointmentDto Map(this Appointment source)
    {
        return new AppointmentDto
        {
            Id = source.Id,
            PatientId = source.PatientId,
            PatientName = source.PatientName,
            ReservedAt = source.ReservedAt,
            SlotId = source.SlotId
        };
    }
}