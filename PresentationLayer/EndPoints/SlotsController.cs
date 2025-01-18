using DataLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.EndPointMarker;

namespace PresentationLayer.EndPoints;

[ApiController]
[Route("api/Slots")]
public class SlotsController(SlotRepo slotRepo) : DoctorAvailabilityEndPoint
{
    [HttpGet]
    public async Task<IActionResult> GetSlots()
        => Ok(await slotRepo.GetAllSlots());
}