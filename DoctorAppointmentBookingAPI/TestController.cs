using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentBookingAPI;

public class TestController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok("Hello World!");
    }
}