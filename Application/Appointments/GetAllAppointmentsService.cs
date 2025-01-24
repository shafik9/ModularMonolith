using Application.Appointments.AppointmentDtos;
using Application.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Appointments;

public class GetAllAppointmentsService(IAppointmentContext appointmentContext) :IApplicationService
{
    public async Task<Result<List<AppointmentDto>>> GetAllAppointments(
        CancellationToken cancellationToken = new CancellationToken())
    {
        var appointments = await appointmentContext.Appointments
            .ToListAsync(cancellationToken: cancellationToken);
        if (appointments.Any())
        {
            return  Result.Success(appointments
                    .Select(a => a.Map()).ToList());
        }

        return Result.Success(new List<AppointmentDto>());
    }
}