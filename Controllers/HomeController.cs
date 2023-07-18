using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.Models;
using Medical_Athena_Calendly.Repository;
using Medical_Athena_Calendly.ViewModel;
using Medical_Athena_Calendly.ViewModel.Calendly;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Diagnostics;
using System.Security.Claims;

namespace Medical_Athena_Calendly.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordEncryption _passwordEncryption;
        private readonly ApiService _apiService;
        private readonly ICalendly _calendly;
        private readonly IAthenaAuth _athenaAuth;

        public HomeController(ILogger<HomeController> logger , IUnitOfWork unitOfWork, IPasswordEncryption passwordEncryption, ApiService apiService, ICalendly calendly, IAthenaAuth athenaAuth)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _passwordEncryption = passwordEncryption;
            _apiService = apiService;
            _calendly = calendly;
            _athenaAuth = athenaAuth;
        }

        public async Task<IActionResult> Dashboard()
        {
            ViewData["ActionName"] = "Dashboard";
            ViewData["ControllerName"] = "Home";
            ViewData["userName"] = HttpContext.Session.GetString("userName");

            await GetAthenaAuth();
            await GetEvents();


            return View("Dashboard", "Home");

        }

        public async Task GetAthenaAuth()
        {
           await  _athenaAuth.Authentication();
        }
        public async Task< List<EventViewModel> > GetEvents()
        {
            //var response = await _calendly.GetAppointmentsForPaitient();
           

            var viewModel = new EventViewModel();
            var events = new List<EventViewModel>();
            //var start = DateTime.Today ;
            //var end = DateTime.Today.AddDays(+30);

            //for (var i = 0; i < response.collection.Count; i++)
            //{
            //    var eventName = response.collection[i].uri + "/invitees";
            //    var linkCollection = await _calendly.GetCancleAndRescheduleLink(eventName);
            //    events.Add(new EventViewModel()
            //    {
            //        id = i,
            //        title = response.collection[i].name ,
            //        start = response.collection[i].start_time.ToString("yyyy-MM-dd'T'HH:mm:ss"),
            //        end = response.collection[i].end_time.ToString("yyyy-MM-dd'T'HH:mm:ss"),
            //        allDay = false,
            //        cancleUrl = linkCollection.collection[0].cancel_url,
            //        rescheduleLink = linkCollection.collection[0].reschedule_url,
            //        url="#"
            //    });

            //    start = start.AddDays(7);
            //    end = end.AddDays(7);
            //}

            var res = events;
            return res;
        }

        public async Task<IActionResult> AddUserInCalendly()
        {
            //var calendly_current_organization = HttpContext.Session.GetString("calendly_current_organization");
            //var token = HttpContext.Session.GetString("calendly_access_token");
            //var apiUrl = calendly_current_organization + "/invitations";

            //CalendlyInviteUserModel request = new CalendlyInviteUserModel();
            //request.email = HttpContext.Session.GetString("userEmail");

            //CalendlyInviteUserOutputModel response = await _apiService.PostAsync<CalendlyInviteUserModel, CalendlyInviteUserOutputModel>(apiUrl, request, token);

            return View("Dashboard", "Home");
        }

    }
}