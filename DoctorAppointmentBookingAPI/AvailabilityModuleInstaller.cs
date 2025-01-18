using Application;
using Application.Appointments;
using DataLayer;
using Infrastructure;
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


    public static IServiceCollection InstallAppointmentModule(this IServiceCollection services)
    {
        services
            .AddDbContext<AppointmentContext>(opt => opt.UseInMemoryDatabase("AvailabilityDB"));
        services.AddScoped<IAppointmentContext>(
            serviceCollection => serviceCollection.GetService<AppointmentContext>()!);

        services.Scan(scan => scan
            .FromAssemblyOf<IApplicationService>()
            .AddClasses(classes => classes.AssignableTo<IApplicationService>())
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        return services;
    }
}