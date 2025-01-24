using Application.Appointments.AppointmentDtos;
using Application.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Appointments;

public class GetAppointmentByIdService(IAppointmentContext appointmentContext) :IApplicationService
{
    public async Task<Result<AppointmentDto>> GetAppointmentById(
        Guid appointmentId,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var appointments = await appointmentContext.Appointments
            .FirstOrDefaultAsync(a => a.Id == appointmentId, cancellationToken: cancellationToken);
        if (appointments != null)
        {
            return Result.Success(appointments.Map());
        }

        return Result.Failure<AppointmentDto>("Appointment not found");
    }
}