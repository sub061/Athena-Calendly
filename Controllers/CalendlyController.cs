using Azure;
using Azure.Core;
using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.ViewModel;
using Medical_Athena_Calendly.ViewModel.Calendly;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Athena_Calendly.Controllers
{
    public class CalendlyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICalendlyAuth _calendlyAuth;
        private readonly ApiService _apiService;
        public CalendlyController(IUnitOfWork unitOfWork, ICalendlyAuth calendlyAuth, ApiService apiService)
        {
            _unitOfWork = unitOfWork;
            _calendlyAuth = calendlyAuth;
            _apiService = apiService;
        }

        /// <summary>
        /// Get Authorize Code for calendly login
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetCalendlyAuthorize()
        {  
            // Calling calendly Authorize api
            var clientId = _calendlyAuth.ClientId();
            var returnUrl = _calendlyAuth.ReturnUrl();
            var redirectUrl = "https://calendly.com/oauth/authorize?client_id=" + clientId + "&response_type=code&redirect_uri=" + returnUrl;

            return Redirect(redirectUrl);

        }
        
        /// <summary>
        /// Callback for calendly
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<IActionResult> ExternalCallbackAsync(string code)
        {
            // Getting  Authorization Code
            var calendlyCode = code;


            // Login to calendly app and get access token
            // Create request object
            AccessTokensRequestModel request = new AccessTokensRequestModel();
            request.grant_type = "authorization_code";   // set grant_type is authorization_code 
            request.code = calendlyCode; // code is return value for authorize api
            request.redirect_uri = _calendlyAuth.ReturnUrl(); //redirect_uri  this is predefine value which we add at app creation time in calendly

            // Get Header Authrization value
            var clientTokan = _calendlyAuth.ClientToken();

            // Make the API POST call for Get Access Token
            var response = await _apiService.PostLoginAsync<AccessTokensRequestModel, AccessTokensResponseModel>("https://auth.calendly.com/oauth/token", request, clientTokan);

            // Store and retrieve access token in session
            HttpContext.Session.SetString("CalendlyAccessToken", response.access_token);

            CalendlyUserModel calendlyUserModel = await GetCurrentCalendlyUser();


            //return RedirectToAction("Dashboard", "Home");

            return RedirectToAction("AddUserInCalendly", "Calendly");
        }
        public async Task<CalendlyUserModel> GetCurrentCalendlyUser()
        {
            var token = HttpContext.Session.GetString("CalendlyAccessToken");
            var apiUrl = "https://api.calendly.com/users/me";
            CalendlyUserModel response = await _apiService.GetAsync<CalendlyUserModel>(apiUrl, token);
            // set current_organization
            HttpContext.Session.SetString("calendly_current_organization", response.resource.current_organization);
            return response;
        }

        public async Task<IActionResult> AddUserInCalendly()
        {
            var organitionCode = HttpContext.Session.GetString("calendly_current_organization");
            var token = HttpContext.Session.GetString("CalendlyAccessToken");
            var apiUrl = organitionCode + "/invitations";

            CalendlyInviteUserModel request = new CalendlyInviteUserModel();
            request.email = HttpContext.Session.GetString("userEmail");

            //CalendlyInviteUserOutputModel responseR = await _apiService.PostAsync<CalendlyInviteUserModel, CalendlyInviteUserOutputModel>(apiUrl, request, token );
            OrganizationInvitations();
            return RedirectToAction("Dashboard", "Home");
        }

        public async Task<IActionResult> ScheduledEvents()
        {
            var token = HttpContext.Session.GetString("CalendlyAccessToken");
            var apiUrl = "https://api.calendly.com/scheduled_events";
            object response = await _apiService.GetAsync<object>(apiUrl, token);
            return View();
        }

        /// <summary>
        /// filter for current user record
        /// </summary>
        /// <param name="currentOrgination"></param>
        /// <returns></returns>
        public async Task<CalendlyInvitation> OrganizationInvitations()
        {
            ViewData["ActionName"] = "OrganizationInvitations";
            ViewData["ControllerName"] = "Home";

            var currentOrgination = HttpContext.Session.GetString("calendly_current_organization");
           
            var apiUrl = currentOrgination + "/invitations?email="+ HttpContext.Session.GetString("userEmail");
            var token = HttpContext.Session.GetString("CalendlyAccessToken");
            var response = await _apiService.GetAsync<CalendlyInvitation>(apiUrl, token);
            return  response;
        }
    }
}
