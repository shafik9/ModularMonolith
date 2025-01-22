using Core.Enum;
using Core.Interfaces;
using Core.Models;
using CSharpFunctionalExtensions;
using Shell.Repos;


namespace Shell.Adapter
{
    public class AppointmentStatusAdapter : IAppointmentStatusPort
    {
        private readonly IAppointmentStatusRepository _repo;
        public AppointmentStatusAdapter(IAppointmentStatusRepository repo)
        {
            _repo = repo;
        }
        public async Task<Result> CancelAppointmentStatus(Guid appointmentId)
        {
            var result = await _repo.ChangeAppointmentStatus(appointmentId, AppointmentStatusEnum.Canceled.GetHashCode());
            if (!result.IsSuccess)
                return Result.Success();
            else
                return Result.Failure("Can't Cancel this Appointment");
        }

        public async  Task<Result> CompleteAppointmentStatus(Guid appointmentId)
        {
            var result = await _repo.ChangeAppointmentStatus(appointmentId, AppointmentStatusEnum.Completed.GetHashCode());
            if (!result.IsSuccess)
                return Result.Success();
            else
                return Result.Failure("Can't Complete this Appointment");
        }
    }
}
