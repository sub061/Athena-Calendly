using Azure;
using Azure.Core;
using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.ViewModel;
using Medical_Athena_Calendly.ViewModel.Calendly;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Text;

namespace Medical_Athena_Calendly.Controllers
{
    public class CalendlyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICalendlyAuth _calendlyAuth;
        private readonly ApiService _apiService;
        private readonly ICalendly _calendly;
        public CalendlyController(IUnitOfWork unitOfWork, ICalendlyAuth calendlyAuth, ApiService apiService, ICalendly calendly)
        {
            _unitOfWork = unitOfWork;
            _calendlyAuth = calendlyAuth;
            _apiService = apiService;
            _calendly = calendly;
        }


        public async  Task<IActionResult> OrganizationMemberships()
        {
            ViewData["ActionName"] = "Practitioner List";
            ViewData["ControllerName"] = "Home";
            ViewData["userEmail"] = HttpContext.Session.GetString("userEmail");
            ViewData["userName"] = HttpContext.Session.GetString("userName");

            var currentOrgination = HttpContext.Session.GetString("calendly_current_organization");
            var url = "https://api.calendly.com/organization_memberships";
            var apiUrl = url+ "/?organization=" + currentOrgination;
            var token = HttpContext.Session.GetString("CalendlyAccessToken");
            var response = await _apiService.GetAsync<CalendlyOrganizationMembership>(apiUrl, token);
            return View(response);
        }
    }
}
