using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.ViewModel.Calendly;
using Microsoft.AspNetCore.Mvc;
using System;

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
            session.SetString("calendly_current_organization", response.resource.current_organization);
            return response;
        }

        /// <summary>
        /// Get user uri 
        /// </summary>
        /// <returns></returns>
        public async Task<string>  GetUserUri()
        {
            var session = _contextAccessor.HttpContext.Session;
            var currentOrgination =  session.GetString("calendly_current_organization");

            //var apiUrl = currentOrgination + "/invitations?email=" + session.GetString("userEmail");
            var apiUrl = currentOrgination + "/invitations";
            var token = session.GetString("CalendlyAccessToken");
            var response = await _apiService.GetAsync<CalendlyInvitation>(apiUrl, token);
            var user = response.collection[0].user;
            session.SetString("calendly_user_uri", user);
            return user;
        }


        public  async Task<AppointmentResponse> GetAppointments()
        {
            var session = _contextAccessor.HttpContext.Session;
            var uri = "";
            var url = "https://api.calendly.com/scheduled_events";
            var user = session.GetString("calendly_user_uri");
            var organization = session.GetString("calendly_current_organization");


            var token = session.GetString("CalendlyAccessToken");
            var apiUrl = url + "?user=" + user + "&organization=" + organization;
            var response = await _apiService.GetAsync<AppointmentResponse>(apiUrl, token);

            return response;
           
        }
    }
}
