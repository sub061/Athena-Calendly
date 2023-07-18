using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.ViewModel.CalCom;
using Medical_Athena_Calendly.ViewModel.Calendly;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Athena_Calendly.Controllers
{
    public class CalController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICal _cal;
        private readonly ApiService _apiService;

        public CalController(IUnitOfWork unitOfWork, ICal cal, ApiService apiService)
        {
            _unitOfWork = unitOfWork;
            _cal = cal;
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> OrganizationMemberships()
        {
            ViewData["ActionName"] = "Organization Memberships";
            ViewData["ControllerName"] = "Home";
            ViewData["userEmail"] = HttpContext.Session.GetString("userEmail");
            ViewData["userName"] = HttpContext.Session.GetString("userName");

            var apiKey = _cal.CalKey();
           
            var url = "https://api.cal.com/memberships?include=team&apiKey=";
            var apiUrl = url + apiKey;

            CalMembership calMembership = new CalMembership();
            var response = await _apiService.GetAsync<CalMembership>(apiUrl, null);
           
            return View(response);
        }
    }
}
