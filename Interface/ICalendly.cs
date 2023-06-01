using Medical_Athena_Calendly.ViewModel.Calendly;

namespace Medical_Athena_Calendly.Interface
{
    public interface ICalendly
    {
        Task<string> GetUserUri();
        Task<CalendlyUserModel> GetCurrentCalendlyAdminUserAndOrganization();
        Task<AppointmentResponse> GetAppointments();
    }
}
