using Microsoft.Extensions.Logging;
using Notifications.Models;

namespace Notifications.NotificationServices;

public class DoctorConfirmationSenderService(ILogger<DoctorConfirmationSenderService> logger)
{
    public async Task Send(AppointmentConfirmation appointmentConfirmation)
    {
        logger.LogInformation(
            $"This Slot has been reserved by {appointmentConfirmation.PatientName} at ${appointmentConfirmation.ReservationDate}");
    }
}