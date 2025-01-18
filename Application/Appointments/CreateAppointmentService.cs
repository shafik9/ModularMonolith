using CSharpFunctionalExtensions;
using Domain;

namespace Application.Appointments;

public class CreateAppointmentService(IAppointmentContext appointmentContext) : IApplicationService
{
    public async Task<Result<Guid>> Create(
        Guid slotId,
        Guid patientId,
        string patientName,
        Guid doctorId)
    {
        var createAppointmentResult = Appointment.Create(
            slotId,
            patientId,
            patientName,
            doctorId);


        if (createAppointmentResult.IsFailure)
        {
            return Result.Failure<Guid>(createAppointmentResult.Error);
        }

        await appointmentContext.Appointments.AddAsync(createAppointmentResult.Value);
        var saveResult = await appointmentContext.SaveChangesWithValidationAsync(default);
        if (saveResult.IsFailure)
        {
            return Result.Failure<Guid>("Failed to save appointment");
        }

        return saveResult.IsSuccess
            ? Result.Success<Guid>(createAppointmentResult.Value.Id)
            : Result.Failure<Guid>(saveResult.Error);
    }
}