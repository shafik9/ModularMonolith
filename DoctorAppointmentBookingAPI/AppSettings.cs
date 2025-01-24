using Application.Interfaces;

namespace DoctorAppointmentBookingAPI;

public class AppSettings(IConfiguration configuration) : IAppSettings
{
    public string? AppointmentConfirmationBaseUrl()
    {
        return configuration.GetValue<string>("AppointmentConfirmationBaseUrl");
    }
}