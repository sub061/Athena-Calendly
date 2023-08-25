using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.ViewModel.Calendly;

namespace Medical_Athena_Calendly.Repository
{
    public class Calendly : ICalendly
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ApiService _apiService;

        public Calendly(IHttpContextAccessor contextAccessor, ApiService apiService)
        {
            _contextAccessor = contextAccessor;
            _apiService = apiService;

        }

        // Create calendly session fo logged user
        public async Task SetCalendlySession()
        {
            var session = _contextAccessor.HttpContext.Session;


            // get calendly access token 
            var token = session.GetString("CalendlyAccessToken");
            // api for getting calendlu user information
            var apiUrl = "https://api.calendly.com/users/me";
            CalendlyUserModel response = await _apiService.GetAsync<CalendlyUserModel>(apiUrl, token);
            // set current_organization

            session.SetString("CalendlyUserEmail", response.resource.email);
            session.SetString("CalendlyUserOrg", response.resource.current_organization);
            session.SetString("CalendlyUserUri", response.resource.uri);
            session.SetString("CalendlySchedulingUrl", response.resource.scheduling_url);
        }


        /// <summary>
        ///  get current admin user and get organization
        /// </summary>
        /// <returns></returns>
        public async Task<CalendlyUserModel> GetCurrentCalendlyAdminUserAndOrganization()
        {
            var session = _contextAccessor.HttpContext.Session;
            var token = session.GetString("CalendlyAccessToken");
            var apiUrl = "https://api.calendly.com/users/me";
            CalendlyUserModel response = await _apiService.GetAsync<CalendlyUserModel>(apiUrl, token);
            // set current_organization
            session.SetString("CalendlyUserOrg", response.resource.current_organization);
            session.SetString("CalendlyUserUri", response.resource.uri);
            session.SetString("CalendlySchedulingUrl", response.resource.scheduling_url);
            return response;
        }



        public async Task<AppointmentsForPaitientRoot> GetAppointmentsForPaitient()
        {
            var session = _contextAccessor.HttpContext.Session;
            var uri = "";
            var url = "https://api.calendly.com/scheduled_events";
            var patientEmail = session.GetString("UserEmail");
            var organization = session.GetString("CalendlyUserOrg");
            var token = session.GetString("CalendlyAccessToken");
            var user = session.GetString("CalendlyUserUri");

            var calendlyUser = session.GetString("CalendlyUserEmail");



            // for sorting
            var sort = "start_time:desc";

            if (calendlyUser == patientEmail)
            {
                var apiUrl = url + "?organization=" + organization + "&sort=" + sort;

                var response = await _apiService.GetAsync<AppointmentsForPaitientRoot>(apiUrl, token);

                return response;

            }
            else
            {
                var apiUrl = url + "?invitee_email=" + patientEmail + "&organization=" + organization + "&sort=" + sort;
                var response = await _apiService.GetAsync<AppointmentsForPaitientRoot>(apiUrl, token);
                return response;
            }

        }

        public async Task<AppointmentsForPaitientRoot> GetAppointmentsForAdmin()
        {
            var session = _contextAccessor.HttpContext.Session;
            var uri = "";
            var url = "https://api.calendly.com/scheduled_events";
            var patientEmail = session.GetString("UserEmail");
            var organization = session.GetString("CalendlyUserOrg");
            var token = session.GetString("CalendlyAccessToken");
            var user = session.GetString("CalendlyUserUri");

            // for sorting
            var sort = "start_time:desc";
            //var apiUrl = url + "?user=" + user + "&organization=" + organization + "&sort=" + sort;
            var apiUrl = url + "?organization=" + organization + "&sort=" + sort;
            var response = await _apiService.GetAsync<AppointmentsForPaitientRoot>(apiUrl, token);

            return response;

        }


        public async Task<AppointmentResponse> GetAppointments()
        {
            var session = _contextAccessor.HttpContext.Session;
            var uri = "";
            var url = "https://api.calendly.com/scheduled_events";
            var user = session.GetString("CalendlyUserUri");
            var organization = session.GetString("CalendlyUserOrg");


            var token = session.GetString("CalendlyAccessToken");
            var apiUrl = url + "?user=" + user + "&organization=" + organization;
            var response = await _apiService.GetAsync<AppointmentResponse>(apiUrl, token);

            return response;

        }

        public async Task<CancleAndRescheduleLinkModel> GetCancleAndRescheduleLink(string apiUrl)
        {
            var session = _contextAccessor.HttpContext.Session;
            var token = session.GetString("CalendlyAccessToken");
            var response = await _apiService.GetAsync<CancleAndRescheduleLinkModel>(apiUrl, token);

            return response;

        }
    }
}
