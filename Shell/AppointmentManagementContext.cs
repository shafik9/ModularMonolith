using Microsoft.EntityFrameworkCore;
using Shell.Entities;

namespace Shell
{

    public class AppointmentManagementContext(DbContextOptions<AppointmentManagementContext> options) : DbContext(options)
    {
        public DbSet<DbAppointmentStatus> AppointmentStatus { get; set; }
    }
}
