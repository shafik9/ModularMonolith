<<<<<<< HEAD
using Core.Interfaces;
=======
using Application;
using Application.Appointments;
>>>>>>> e1ca13ee214c8313524f5bc0c86961cc27dc71ba
using DataLayer;
using Infrastructure;
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