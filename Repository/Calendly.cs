﻿using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.ViewModel.Calendly;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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
            session.SetString("calendly_user_uri", response.resource.uri);
            session.SetString("calendly_scheduling_url", response.resource.scheduling_url);
            return response;
        }



        public async Task<AppointmentsForPaitientRoot> GetAppointmentsForPaitient()
        {
            var session = _contextAccessor.HttpContext.Session;
            var uri = "";
            var url = "https://api.calendly.com/scheduled_events";
            var patientEmail = session.GetString("userEmail");
            var organization = session.GetString("calendly_current_organization");
            var token = session.GetString("CalendlyAccessToken");
            var user = session.GetString("calendly_user_uri");

            // for sorting
            var sort = "start_time:desc";
            //var apiUrl = url + "?user=" + user + "&organization=" + organization + "&sort=" + sort;
            var apiUrl = url + "?invitee_email="+patientEmail+"&organization=" +organization+"&sort="+sort;
            var response = await _apiService.GetAsync<AppointmentsForPaitientRoot>(apiUrl, token);

            return response;

        }


        public async Task<AppointmentResponse> GetAppointments()
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

        public async Task<CancleAndRescheduleLinkModel> GetCancleAndRescheduleLink(string apiUrl)
        {
            var session = _contextAccessor.HttpContext.Session;
            var token = session.GetString("CalendlyAccessToken");
            var response = await _apiService.GetAsync<CancleAndRescheduleLinkModel>(apiUrl, token);

            return response;

        }
    }
}
