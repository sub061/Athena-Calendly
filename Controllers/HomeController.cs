using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.Models;
using Medical_Athena_Calendly.Repository;
using Medical_Athena_Calendly.ViewModel.Calendly;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Diagnostics;

namespace Medical_Athena_Calendly.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordEncryption _passwordEncryption;
        private readonly ApiService _apiService;
        private readonly ICalendly _calendly;

        public HomeController(ILogger<HomeController> logger , IUnitOfWork unitOfWork, IPasswordEncryption passwordEncryption, ApiService apiService, ICalendly calendly)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _passwordEncryption = passwordEncryption;
            _apiService = apiService;
            _calendly = calendly;
        }

        public async Task<IActionResult> Dashboard()
        {
            ViewData["ActionName"] = "Dashboard";
            ViewData["ControllerName"] = "Home";

            var response = await _calendly.GetAppointments();

            if (response.EventCollection == null)
            {
                // use no meeting and 
                return View("Dashboard", "Home");
            }

            return View("Dashboard", "Home");

        }



        //public async Task<IActionResult> ShowMeeting()
        //{
        //    ViewData["ActionName"] = "Meeting";
        //    ViewData["ControllerName"] = "Home";

        //    return View("Dashboard");

        //    //CalendlyInviteUserOutputModel responce = await AddUserInCalendly(currentUser.resource.current_organization);
        //    //var responce = await OrganizationInvitations(currentUser.resource.current_organization);

        //    //return PartialView("_CalendlyUser", responce.resource);
        //    return View();
        //}

        //    public async Task<CalendlyUserModel> GetCurrentUser()
        //    {
        //        var token = HttpContext.Session.GetString("CalendlyAccessToken");
        //        var apiUrl = "https://api.calendly.com/users/me";
        //        CalendlyUserModel response = await _apiService.GetAsync<CalendlyUserModel>(apiUrl, token);
        //        return response;
        //}

        //Invites a user to an organization.
        public async Task<IActionResult> AddUserInCalendly()
        {
            var calendly_current_organization = HttpContext.Session.GetString("calendly_current_organization");
            var token = HttpContext.Session.GetString("CalendlyAccessToken");
            var apiUrl = calendly_current_organization + "/invitations";

            CalendlyInviteUserModel request = new CalendlyInviteUserModel();
            request.email = HttpContext.Session.GetString("userEmail");

            CalendlyInviteUserOutputModel response = await _apiService.PostAsync<CalendlyInviteUserModel, CalendlyInviteUserOutputModel>(apiUrl, request, token);

            return View("Dashboard", "Home");
        }

        

    }
}