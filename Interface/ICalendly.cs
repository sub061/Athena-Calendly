﻿using Medical_Athena_Calendly.ViewModel.Calendly;

namespace Medical_Athena_Calendly.Interface
{
    public interface ICalendly
    {
        Task<AppointmentsForPaitientRoot> GetAppointmentsForAdmin();
        Task SetCalendlySession();
        Task<CancleAndRescheduleLinkModel> GetCancleAndRescheduleLink(string apiUrl);
        Task<AppointmentsForPaitientRoot> GetAppointmentsForPaitient();
        //Task<string> GetUserUri();
        Task<CalendlyUserModel> GetCurrentCalendlyAdminUserAndOrganization();
        Task<AppointmentResponse> GetAppointments();
    }
}
