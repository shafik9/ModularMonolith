using Core.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Shell;
using Shell.Adapter;
using Shell.Repos;

namespace DoctorAppointmentBookingAPI;

public static class AvailabilityModuleInstaller
{
    public static IServiceCollection InstallAvailabilityModules(this IServiceCollection services)
    {
        services.AddScoped<SlotRepo>();
        services.AddScoped<AppointmentStatusRepository>();
        services.AddScoped<IAppointmentStatusPort, AppointmentStatusAdapter>();
        services.AddDbContext<DoctorAvailabilityContext>(opt => opt.UseInMemoryDatabase("AvailabilityDB"));
        services.AddDbContext<AppointmentManagementContext>(opt => opt.UseInMemoryDatabase("AppointmentManagmentDB"));
        return services;
    }
}