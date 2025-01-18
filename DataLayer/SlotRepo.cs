using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class SlotRepo(DoctorAvailabilityContext doctorAvailabilityContext)
{
    public async Task<List<DbSlot>> GetAllSlots()
        => await doctorAvailabilityContext.Slots.ToListAsync();
    
}