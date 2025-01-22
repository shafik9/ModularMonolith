

using CSharpFunctionalExtensions;

namespace Core.Interfaces
{
    public interface IAppointmentStatusRepository
    {
        Task<Result> ChangeAppointmentStatus(Guid appointmentId, int statusId);
    }
}
