using CSharpFunctionalExtensions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IAppointmentContext
{
    public DbSet<Appointment> Appointments { get; set; }

    Task<Result> SaveChangesWithValidationAsync(CancellationToken cancellationToken = new CancellationToken());
}