using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentBookingAPI;

public static class AvailabilityModuleInstaller
{
    public static IServiceCollection InstallAvailabilityModules(this IServiceCollection services)
    {
        services.AddScoped<SlotRepo>();
        services
            .AddDbContext<DoctorAvailabilityContext>(opt => opt.UseInMemoryDatabase("AvailabilityDB"));
        return services;
    }
}