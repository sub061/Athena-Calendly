using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Medical_Athena_Calendly.Controllers
{
    [Route("appointment/{app}")]
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICalendlyAuth _calendlyAuth;
        private readonly ApiService _apiService;
        private readonly ICalendly _calendly;
        public AppointmentController(IUnitOfWork unitOfWork, ICalendlyAuth calendlyAuth, ApiService apiService, ICalendly calendly)
        {
            _unitOfWork = unitOfWork;
            _calendlyAuth = calendlyAuth;
            _apiService = apiService;
            _calendly = calendly;
        }

        [Route("*")]

        [Route("scheduling")]
        public async Task<IActionResult> Scheduling(string app)
        {
            ViewData["CalendlyUser"] = app;
            ViewData["ActionName"] = "Appointment Scheduling";
            //ViewData["ControllerName"] = "Home";
            ViewData["UserEmail"] = HttpContext.Session.GetString("UserEmail");
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["CalendlySchedulingUrl"] = HttpContext.Session.GetString("CalendlySchedulingUrl");
            return View("Scheduling");
        }
    }
}
