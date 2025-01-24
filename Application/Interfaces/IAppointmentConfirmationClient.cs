using Domain;

namespace Application.Interfaces;

public interface IAppointmentConfirmationClient
{
    void SendAppointmentConfirmation(Appointment appointment);
}