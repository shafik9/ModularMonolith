using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class DoctorAvailabilityContext(DbContextOptions<DoctorAvailabilityContext> options) : DbContext(options)
{
    public DbSet<DbSlot> Slots { get; set; }
}