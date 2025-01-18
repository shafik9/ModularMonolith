using Application.Appointments;
using Application.Appointments.AppointmentDtos;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.EndPoint;

[ApiController]
[Route("api/[controller]")]
public class AppointmentBookingEndPoint(
    CreateAppointmentService createAppointmentService,
    GetAllAppointmentsService allAppointmentsService,
    GetAppointmentByIdService appointmentByIdService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<AppointmentDto>>> GetAppointments()
    {
        var appointments = await allAppointmentsService.GetAllAppointments();

        return Ok(appointments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppointmentDto>> GetAppointment(Guid id)
    {
        var appointmentResult = await appointmentByIdService.GetAppointmentById(id);
        if (appointmentResult.IsFailure)
        {
            return BadRequest(appointmentResult.Error);
        }

        return Ok(appointmentResult.Value);
    }

    [HttpPost]
    public async Task<IActionResult> AddAppointment(AppointmentDto appointment)
    {
        var createResult = await createAppointmentService
            .Create(appointment.Id, appointment.PatientId, appointment.PatientName,
                appointment.DoctorId);
        if (createResult.IsFailure)
            return BadRequest(createResult.Error);


        return Ok();
    }
}