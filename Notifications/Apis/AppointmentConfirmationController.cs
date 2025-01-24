using Microsoft.AspNetCore.Mvc;
using Notifications.DataAccess;
using Notifications.Dtos;
using Notifications.EndpointMarker;
using Notifications.Models;
using Notifications.NotificationServices;

namespace Notifications.Apis;

[ApiController]
[Route("api/[controller]")]
public class AppointmentConfirmationController(
    AppointmentConfirmationContext appointmentConfirmationContext,
    DoctorConfirmationSenderService doctorConfirmationSenderService,
    PatientConfirmationSenderService patientConfirmationSenderService)
    : AppointmentConfirmationEndPointMarker
{
    [HttpGet("CreateAppointmentConfirmation")]
    public async Task<ActionResult> CreateAppointmentConfirmation(AddConfirmationDto addConfirmationDto)
    {
        var appointmentConfirmation = AppointmentConfirmation.Create(addConfirmationDto);


        appointmentConfirmationContext.AppointmentConfirmations.Add(appointmentConfirmation);

        var rowsEffected = await appointmentConfirmationContext.SaveChangesAsync();
        if (rowsEffected == 0)
            return BadRequest();

        await doctorConfirmationSenderService.Send(appointmentConfirmation);
        await patientConfirmationSenderService.Send(appointmentConfirmation);
        return Ok();
    }
}