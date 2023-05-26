using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.Repository;
using Medical_Athena_Calendly.ViewModel;
using Medical_Athena_Calendly.ViewModel.Athena;
using Microsoft.AspNetCore.Mvc;


namespace Medical_Athena_Calendly.Controllers
{
    public class AthenaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAthenaAuth _athenaAuth;
        private readonly ApiService _apiService;
        public AthenaController(IUnitOfWork unitOfWork, IAthenaAuth athenaAuth, ApiService apiService)
        {
            _apiService = apiService;
            _unitOfWork = unitOfWork;
            _athenaAuth = athenaAuth;
        }

        public IActionResult Index()
        {

            return RedirectToAction("Token");
        }

        public async Task<IActionResult> Token()
        {
            // Create request object
            //AthenaTokanRequestModel request = new AthenaTokanRequestModel();
            //request.grant_type = "client_credentials";
            //request.scope = _athenaAuth.Scope();

            Dictionary<string, string> request = new Dictionary<string, string>
            {
                {"grant_type","client_credentials"},
                {"scope", _athenaAuth.Scope() }
            };

            // Get Header Authrization value
            var clientTokan = _athenaAuth.ClientToken();

            // Get api endpoint
            var apiEndpoint = _athenaAuth.APIEndpoint();
            var apiVersion = _athenaAuth.APIVersion();
            var authAPI = apiEndpoint + "oauth2/" + apiVersion + "/token";

            // Make the API POST call for Get Access Token
            var response = await _apiService.PostAsync<AthenaTokanResponseModel>(authAPI, request, clientTokan);

            // Store and retrieve access token in session
            HttpContext.Session.SetString("AthenaAccessToken", response.access_token);
            return RedirectToAction("AppointmentConfirmedStatuses");
        }

        public async Task<IActionResult> AppointmentConfirmedStatuses()
        {
            // Get access code
            var accessToken = HttpContext.Session.GetString("AthenaAccessToken");

            // get PracticedId
            var practicedId = _athenaAuth.PracticedId();

            var apiEndpoint = _athenaAuth.APIEndpoint();
            var apiVersion = _athenaAuth.APIVersion();
            var authAPI = apiEndpoint + apiVersion + "/"+ practicedId + "/reference/appointmentconfirmationstatus";
            var responce = await _apiService.GetAsync<AppointmentsConfirmationStatusModel>(authAPI, accessToken);
            return View("Index");
        }
    }
}
