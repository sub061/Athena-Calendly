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

            var sexualOrientation = SexualOrientationData.GetData();
            ViewData["SexualOrientation"] = sexualOrientation;

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

            var assignedSexAtBirth = new AssignedSexAtBirth
            {
                DropdownOptions = Enum.GetValues(typeof(AssignedSexAtBirthEnum))
            .Cast<AssignedSexAtBirthEnum>()
            .Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            })
            };

            var maritalStatus = new MaritalStatus
            {
                DropdownOptions = Enum.GetValues(typeof(MaritalStatusEnum))
           .Cast<MaritalStatusEnum>()
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


            var booleanValue = new BooleanValue
            {
                DropdownOptions = Enum.GetValues(typeof(BooleanValueEnum))
          .Cast<BooleanValueEnum>()
          .Select(e => new SelectListItem
          {
              Value = e.ToString(),
              Text = e.ToString()
          })
            };

            var relationshipe = new Relationship
            {
                DropdownOptions = Enum.GetValues(typeof(ContactRelationshipEnum))
     .Cast<ContactRelationshipEnum>()
     .Select(e => new SelectListItem
     {
         Value = e.ToString(),
         Text = e.ToString()
     })
            };

            PatientModel model = new PatientModel();
            model.contactpreference = contactPreference;
            model.sex = sex;
            model.maritalstatus = maritalStatus;
            model.assignedsexatbirth = assignedSexAtBirth;
            model.homeboundyn = booleanValue;
            model.contactrelationship = relationshipe;
            model.nextkinrelationship = relationshipe;


            return View("PatientRegistration", model);
        }
        public async Task<IActionResult> CreateAsync()
        {


            return RedirectToAction("Dashboard", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientModel patient)
        {
            // Get access code
            var accessToken = HttpContext.Session.GetString("athena_access_token");

            // get PracticedId
            var practicedId = _athenaAuth.PracticedId();
            // API endpoint
            var apiEndpoint = _athenaAuth.APIEndpoint();
            var apiVersion = _athenaAuth.APIVersion();
            // 
            var authAPI = apiEndpoint + apiVersion + "/" + practicedId + "/patients";
            Dictionary<string, string> parameters = DictionaryData.ConvertToDictionary(patient);
            var responce = await _apiService.PostAsync<PatientPostResponceModel>(authAPI, parameters, accessToken);

            return RedirectToAction("Dashboard" ,"Home");
        }
    }
}
