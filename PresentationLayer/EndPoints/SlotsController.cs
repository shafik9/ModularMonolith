using BusinessLayer;
using CSharpFunctionalExtensions;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Dtos;
using PresentationLayer.EndPointMarker;

namespace PresentationLayer.EndPoints;

[ApiController]
[Route("api/[controller]")]
public class SlotsController(SlotRepo slotRepo) : DoctorAvailabilityEndPoint
{
    [HttpGet("AllSlots")]
    public async Task<ActionResult<List<SlotDto>>> GetSlots()
    {
        var slots = await slotRepo.GetAllSlots();
        var slotsDto = slots.Select(a => new SlotDto()
        {
            StartTime = a.StartTime,
            EndTime = a.EndTime,
            DoctorId = a.DoctorId,
            DoctorName = a.DoctorName,
            Cost = a.Cost
        }).ToList();
        
        return Ok(slotsDto);
    }


    [HttpGet("AvailableSlots")]
    public async Task<ActionResult<List<SlotDto>>> GetAvailableSlots()
    {
        var slots = await slotRepo.GetAvailableSlots();
        var slotsDto = slots.Select(a => new SlotDto()
        {
            StartTime = a.StartTime,
            EndTime = a.EndTime,
            DoctorId = a.DoctorId,
            DoctorName = a.DoctorName,
            Cost = a.Cost
        }).ToList();
        
        return Ok(slotsDto);
    }

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