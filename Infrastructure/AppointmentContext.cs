using Application;
using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppointmentContext : DbContext ,IAppointmentContext
{

    public AppointmentContext(DbContextOptions<AppointmentContext> options) 
    {
        
    }

    public DbSet<Appointment> Appointments { get; set; }


    
    public async Task<Result> SaveChangesWithValidationAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            await SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
        catch (Exception e)
        {
            return Result.Failure(e.Message);
        }
    }
    
}