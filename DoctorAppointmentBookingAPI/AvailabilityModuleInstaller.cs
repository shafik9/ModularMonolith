using Application;
using Application.Interfaces;
using Core.Interfaces;
using DataLayer;
using Infrastructure;
using Infrastructure.AppointmentConfirmation;
using Microsoft.EntityFrameworkCore;
using Notifications.DataAccess;
using Notifications.NotificationServices;
using Shell;
using Shell.Adapter;
using Shell.Repos;

namespace DoctorAppointmentBookingAPI;

public static class AvailabilityModuleInstaller
{
    public static IServiceCollection InstallAvailabilityModules(this IServiceCollection services)
    {
        services.AddScoped<SlotRepo>();
        services.AddDbContext<DoctorAvailabilityContext>(opt => opt.UseInMemoryDatabase("AvailabilityDB"));
        return services;
    }


    public static IServiceCollection InstallAppointmentModule(this IServiceCollection services)
    {
        services.AddDbContext<AppointmentContext>(opt => opt.UseInMemoryDatabase("AvailabilityDB"));
        services.AddScoped<IAppointmentContext>(
            serviceCollection => serviceCollection.GetService<AppointmentContext>()!);

        services.Scan(scan => scan
            .FromAssemblyOf<IApplicationService>()
            .AddClasses(classes => classes.AssignableTo<IApplicationService>())
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        
        services.AddScoped<IAppSettings, AppSettings>();
        services.AddScoped<IAppointmentConfirmationClient, AppointmentConfirmationClient>();
        return services;
    }

    public static IServiceCollection InstallAppointmentManagement(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentStatusRepository, AppointmentStatusRepository>();
        services.AddScoped<IAppointmentStatusPort, AppointmentStatusAdapter>();
        services.AddDbContext<AppointmentManagementContext>(opt => opt.UseInMemoryDatabase("AppointmentManagementDB"));
        return services;
    }
    
    
    public static IServiceCollection InstallAppointmentConfirmationModule(this IServiceCollection services)
    {
        services.AddScoped<AppointmentConfirmationContext>();
        services.AddScoped<PatientConfirmationSenderService>();
        services.AddScoped<DoctorConfirmationSenderService>();
        services.AddDbContext<AppointmentManagementContext>(opt => opt.UseInMemoryDatabase("AppointmentConfirmationDB"));
        return services;
    }

}