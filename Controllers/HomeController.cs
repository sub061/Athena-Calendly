using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Athena_Calendly.Controllers
{
    [Route("home/{app}")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordEncryption _passwordEncryption;
        private readonly ApiService _apiService;
        private readonly ICalendly _calendly;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IPasswordEncryption passwordEncryption, ApiService apiService, ICalendly calendly)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _passwordEncryption = passwordEncryption;
            _apiService = apiService;
            _calendly = calendly;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> DashBoardShow(string app, List<EventViewModel> model)
        {
            // create view data 
            ViewData["ActionName"] = "Dashboard";
            ViewData["ControllerName"] = "Home";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["CalendlyUser"] = HttpContext.Session.GetString("CalendlyUser");
            if (model.Count == 0)
            {
                model = await GetEvents();
            }
            return View("Dashboard", model);

        }

        [Route("dashboard")]
        [HttpGet]
        public async Task<IActionResult> Dashboard(string app)
        {
            //var userName = HttpContext.Session.GetString("UserEmail");
            //var calendlyUser = HttpContext.Session.GetString("CalendlyUserEmail");
            //if (userName == calendlyUser)
            //{
            //    return RedirectToAction("AdminDashboard", "Home", app);
            //}


            // call event function to get appointment data for log user
            var result = await GetEvents();
            if (result.Count > 0)
            {
                //return RedirectToRoute("home/" + app, result);
                return RedirectToAction("DashBoardShow", "Home", new { app, result });
            }
            //return RedirectToRoute("book-appointment/" + app);
            return RedirectToAction("Scheduling", "Appointment", app);

        }
        [Route("admindashboard")]
        [HttpGet]
        public async Task<IActionResult> AdminDashboard(string app)
        {
            var result = await GetAdminEvents();

            //return RedirectToRoute("home/" + app, result);
            return RedirectToAction("DashBoardShow", "Home", new { app, result });


        }

        [Route("patientdetails")]
        public IActionResult PatientDetails()
        {
            ViewData["ActionName"] = "Patient Details";
            ViewData["ControllerName"] = "Home";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["CalendlyUser"] = HttpContext.Session.GetString("CalendlyUser");
            return View("Form");
        }

        public async Task<List<EventViewModel>> GetEvents()
        {
            // call appointment api to get appointment record for log user
            var response = await _calendly.GetAppointmentsForPaitient();
            var viewModel = new EventViewModel();
            var events = new List<EventViewModel>();
            var start = DateTime.Today;
            var end = DateTime.Today.AddDays(+30);

            for (var i = 0; i < response.collection.Count; i++)
            {
                var eventName = response.collection[i].uri + "/invitees";
                var linkCollection = await _calendly.GetCancleAndRescheduleLink(eventName);
                events.Add(new EventViewModel()
                {

                    id = i,
                    title = response.collection[i].name,
                    start = response.collection[i].start_time.UtcDateTime,
                    end = response.collection[i].end_time.UtcDateTime,
                    //end = response.collection[i].end_time.ToString("yyyy-MM-dd'T'HH:mm:ss"),
                    allDay = false,
                    cancleUrl = linkCollection.collection[0].cancel_url,
                    rescheduleLink = linkCollection.collection[0].reschedule_url,
                    url = "#"
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }

            var res = events;
            return res;
        }


        public async Task<List<EventViewModel>> GetAdminEvents()
        {
            // call appointment api to get appointment record for log user
            var response = await _calendly.GetAppointmentsForAdmin();
            var viewModel = new EventViewModel();
            var events = new List<EventViewModel>();
            var start = DateTime.Today;
            var end = DateTime.Today.AddDays(+30);

            for (var i = 0; i < response.collection.Count; i++)
            {
                var eventName = response.collection[i].uri + "/invitees";
                var linkCollection = await _calendly.GetCancleAndRescheduleLink(eventName);
                events.Add(new EventViewModel()
                {

                    id = i,
                    title = response.collection[i].name,
                    start = response.collection[i].start_time.UtcDateTime,
                    end = response.collection[i].end_time.UtcDateTime,
                    //end = response.collection[i].end_time.ToString("yyyy-MM-dd'T'HH:mm:ss"),
                    allDay = false,
                    cancleUrl = linkCollection.collection[0].cancel_url,
                    rescheduleLink = linkCollection.collection[0].reschedule_url,
                    url = "#"
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }

            var res = events;
            return res;
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}