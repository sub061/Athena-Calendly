using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.ViewModel.Athena;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Medical_Athena_Calendly.Controllers
{
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAthenaAuth _athenaAuth;
        private readonly ApiService _apiService;

        public PatientController(IUnitOfWork unitOfWork, IAthenaAuth athenaAuth, ApiService apiService)
        {
            _unitOfWork = unitOfWork;
            _athenaAuth = athenaAuth;
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            ViewData["ActionName"] = "Patient Registration";
            ViewData["ControllerName"] = "Athena";

            var language = LanguageData.GetData();
            ViewData["Language"] = language;
         
            var contactPreference = new ContactPreference
            {
                DropdownOptions = Enum.GetValues(typeof(ContactPreferenceEnum))
            .Cast<ContactPreferenceEnum>()
            .Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            })
            };


            var sex = new Sex
            {
                DropdownOptions = Enum.GetValues(typeof(SexEnum))
            .Cast<SexEnum>()
            .Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            })
            };

            PatientModel model = new PatientModel();
            model.contactpreference = contactPreference;
            model.sex = sex;
            

            return View("PatientRegistration", model);
        }

        public async Task<IActionResult> CreateAsync(PatientModel patient)
        {
            // Get access code
            var accessToken = HttpContext.Session.GetString("AthenaAccessToken");

            // get PracticedId
            var practicedId = _athenaAuth.PracticedId();
            // API endpoint
            var apiEndpoint = _athenaAuth.APIEndpoint();
            var apiVersion = _athenaAuth.APIVersion();
            // 
            var authAPI = apiEndpoint + apiVersion + "/" + practicedId + "/patients";
            Dictionary<string, string> parameters = DictionaryData.ConvertToDictionary(patient);
            var responce = await _apiService.PostAsync<PatientPostResponceModel>(authAPI, parameters, accessToken);

            return View();
        }
    }
}
