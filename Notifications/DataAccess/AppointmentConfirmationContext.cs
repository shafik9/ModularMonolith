using Microsoft.EntityFrameworkCore;
using Notifications.Models;

namespace Notifications.DataAccess;

public class AppointmentConfirmationContext(DbContextOptions<AppointmentConfirmationContext> options)
    : DbContext(options)
{
    public DbSet<AppointmentConfirmation> AppointmentConfirmations { get; set; }
}