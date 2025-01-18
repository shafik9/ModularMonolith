using CSharpFunctionalExtensions;

namespace Domain;

public class Appointment
{
    public Guid Id { get; set; }
    public Guid SlotId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public string PatientName { get; set; }
    public DateTime ReservedAt { get; set; }


    public static Result<Appointment> Create(Guid slotId,
        Guid patientId,
        string patientName,
        Guid doctorId)
    {
        if (slotId == Guid.Empty)
            return Result.Failure<Appointment>("SlotId is required");

        if (patientId == Guid.Empty)
            return Result.Failure<Appointment>("PatientId is required");

        if (string.IsNullOrWhiteSpace(patientName))
            return Result.Failure<Appointment>("PatientName is required");

        var appointment = new Appointment
        {
            Id = Guid.NewGuid(),
            SlotId = slotId,
            PatientId = patientId,
            PatientName = patientName,
            ReservedAt = DateTime.UtcNow,
            DoctorId = doctorId,
            
        };

        return Result.Success(appointment);
    }
}