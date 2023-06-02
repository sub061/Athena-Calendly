using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.ViewModel.Calendly;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Athena_Calendly.Controllers
{
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

        public async Task<IActionResult> GetAppointments()
        {
            var response = await _calendly.GetAppointments();
            ViewData["userEmail"] = HttpContext.Session.GetString("userEmail");
            ViewData["userName"] = HttpContext.Session.GetString("userName");


            if(response.EventCollection == null)
            {
                // use no meeting and 
                return View ("Dashboard", "Home");
            }
            // show meeting
            return RedirectToAction("Dashboard", "Home");
        }
    }
}
