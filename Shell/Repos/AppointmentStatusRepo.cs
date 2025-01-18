using Shell.Entities;


namespace Shell.Repos
{
    public class AppointmentStatusRepository
    {
        private readonly AppointmentManagementContext _doctorAvailabilityContext;
        public AppointmentStatusRepository(AppointmentManagementContext doctorAvailabilityContext)
        {
            _doctorAvailabilityContext = doctorAvailabilityContext;
        }

        public async Task<DbAppointmentStatus> ChangeAppointmentStatus(Guid appointmentId, int statusId)
        {
            var dbModel = new DbAppointmentStatus
            {
                AppointmentId = appointmentId,
                Id = new Guid(),
                StatusId = statusId
            };

            _doctorAvailabilityContext.AppointmentStatus.Add(dbModel);
            await _doctorAvailabilityContext.SaveChangesAsync();
            return dbModel;
        }
    }
}
