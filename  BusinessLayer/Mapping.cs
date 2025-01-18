using DataLayer.Entities;

namespace BusinessLayer;

public static class Mapping
{
    public static DbSlot Map(this Slot source)
    {
        return new DbSlot
        {
            Cost = source.Cost,
            DoctorName = source.DoctorName,
            DoctorId = source.DoctorId,
            Id = source.Id,
            IsReserved = source.IsReserved,
            StartTime = source.StartTime,
            EndTime = source.EndTime
        };
    }
}