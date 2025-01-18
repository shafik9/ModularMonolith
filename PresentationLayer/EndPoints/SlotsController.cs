using BusinessLayer;
using CSharpFunctionalExtensions;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Dtos;
using PresentationLayer.EndPointMarker;

namespace PresentationLayer.EndPoints;

[ApiController]
[Route("api/Slots")]
public class SlotsController(SlotRepo slotRepo) : DoctorAvailabilityEndPoint
{
    [HttpGet]
    public async Task<IActionResult> GetSlots()
        => Ok(await slotRepo.GetAllSlots());

    [HttpPost]
    public async Task<IActionResult> CreateSlot([FromBody] SlotDto slotDto)
    {
        var createdSlot = Slot
            .Create
            (
                slotDto.StartTime,
                slotDto.EndTime,
                slotDto.DoctorId,
                slotDto.DoctorName,
                slotDto.Cost
            );

        if (createdSlot.IsFailure)
            return BadRequest(createdSlot.Error);

        var dbSlot = createdSlot.Value.Map<DbSlot>();


        await slotRepo.AddSlot(dbSlot);

        return Ok();
    }
}