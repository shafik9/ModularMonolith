using CSharpFunctionalExtensions;


namespace Core.Interfaces
{
    public interface IAppointmentStatusPort
    {

        Task<Result> CompleteAppointmentStatus(Guid appointmentId);
        Task<Result> CancelAppointmentStatus(Guid appointmentId);
    }
}
