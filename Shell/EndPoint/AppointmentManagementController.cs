using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shell.EndPointMarker;


namespace Shell.EndPoint
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentManagementController : AppointmentStatusEndPoint
    {
        private readonly IAppointmentStatusPort _port;
        public AppointmentManagementController(IAppointmentStatusPort port)
        {
            _port = port;
        }


        [HttpGet("CompleteAppointment")]
        public async Task<IActionResult> CompleteAppointment([FromBody] Guid appointmentId)
        {
            var result = await _port.CompleteAppointmentStatus(appointmentId);
            if(result.IsSuccess)
                return Ok();

            return BadRequest(result);

        }


        [HttpGet("CancelAppointment")]
        public async Task<IActionResult> CancelAppointment([FromBody] Guid appointmentId)
        {
            var result = await _port.CancelAppointmentStatus(appointmentId);
            if (result.IsSuccess)
                return Ok();

            return BadRequest(result);

        }
    }
}
