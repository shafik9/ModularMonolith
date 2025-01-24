using System.Text;
using Application.Interfaces;
using Domain;
using Newtonsoft.Json;

namespace Infrastructure.AppointmentConfirmation;

public class AppointmentConfirmationClient(HttpClient httpClient, IAppSettings appSettings)
    : IAppointmentConfirmationClient
{
    public void SendAppointmentConfirmation(Appointment appointment)
    {
        var confirmationModuleBaseUrl = appSettings.AppointmentConfirmationBaseUrl();

        var jsonData = JsonConvert.SerializeObject(new PostConfirmationAppointmentDto());
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        Task.Run(async () => await httpClient.PostAsync(confirmationModuleBaseUrl, content));
    }
}