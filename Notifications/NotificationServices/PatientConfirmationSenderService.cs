using Microsoft.Extensions.Logging;
using Notifications.Models;

namespace Notifications.NotificationServices;

public class PatientConfirmationSenderService(ILogger<DoctorConfirmationSenderService> logger)
{
    public async Task Send(AppointmentConfirmation appointmentConfirmation)
    {
        logger.LogInformation(
            $"you are confirmed the reservation at {appointmentConfirmation.ReservationDate} for Doctor {appointmentConfirmation.DoctorName}");
    }
}