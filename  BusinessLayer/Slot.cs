using CSharpFunctionalExtensions;

namespace BusinessLayer;

public class Slot
{
    private Slot()
    {
    }

    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid DoctorId { get; set; }
    public string? DoctorName { get; set; }
    public bool IsReserved { get; set; }
    public decimal Cost { get; set; }

    // add static create method
    public static Result<Slot> Create(
        DateTime startTime,
        DateTime endTime,
        Guid doctorId,
        string? doctorName,
        decimal cost)
    {
        if (startTime >= endTime)
        {
            return Result.Failure<Slot>("Start time must be before end time");
        }

        if (doctorId == Guid.Empty)
        {
            return Result.Failure<Slot>("DoctorId must be set");
        }

        if (string.IsNullOrWhiteSpace(doctorName))
        {
            return Result.Failure<Slot>("DoctorName must be set");
        }

        if (cost <= 0)
        {
            return Result.Failure<Slot>("Cost must be greater than 0");
        }


        return Result.Success(new Slot()
        {
            Id = Guid.NewGuid(),
            StartTime = startTime,
            EndTime = endTime,
            DoctorId = doctorId,
            DoctorName = doctorName,
            Cost = cost,
            IsReserved = false
        });
    }
}