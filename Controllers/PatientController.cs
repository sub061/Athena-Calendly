using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.ViewModel.Athena;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Athena_Calendly.Controllers
{
    [Route("Patient/{app}")]
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAthenaAuth _athenaAuth;
        private readonly ApiService _apiService;
        private readonly IUser _user;

        public PatientController(IUnitOfWork unitOfWork, IAthenaAuth athenaAuth, ApiService apiService, IUser user)
        {
            _unitOfWork = unitOfWork;
            _athenaAuth = athenaAuth;
            _apiService = apiService;
            _user = user;
        }

        [NonAction]
        public async Task<int> GetPatientId(string email, int departmentId, string dob)
        {
            PatientSearchVM response = await _athenaAuth.PatientSearch(email, departmentId, dob);
            if (response.totalcount > 0)
            {
                return Convert.ToInt32(response.patients[0].patientid);
            }
            return 0;
        }


        [NonAction]
        public async Task<int> Registration(NewPatientModel model)
        {
            var accessToken = await _athenaAuth.Token();
            // Get base url
            var url = await _athenaAuth.GetBaseUrl();
            var authAPI = "patients";
            Dictionary<string, string> parameters = DictionaryData.ConvertToDictionary(model);

            var responce = await _apiService.AthenaPostAsync(authAPI, parameters, accessToken);

            return 1;
        }

        public IActionResult Index()
        {
            ViewData["CalendlyUser"] = HttpContext.Session.GetString("CalendlyUser");
            ViewData["ActionName"] = "Patient Profile";
            ViewData["ControllerName"] = "Athena";

            var language = LanguageData.GetData();
            ViewData["Language"] = language;


            var email = HttpContext.Session.GetString("UserEmail");

            NewPatientModel model = new NewPatientModel();
            var userDetails = _user.FindByCondition(m => m.Email == email).FirstOrDefault();

            model.email = email;
            model.firstname = userDetails.FirstName;
            model.lastname = userDetails.LastName;
            //model.dob = userDetails.DOB;
            model.departmentid = 1;




            return View("PatientRegistration", model);
        }
        [HttpPost]
        [Route("CreateAsync")]
        public async Task<IActionResult> CreateAsync(string app, NewPatientModel patient)
        {

            var id = _athenaAuth.DepartmentId(app);
            patient.departmentid = id;

            //NewPatientModel newPatientModel = new NewPatientModel();
            //newPatientModel.firstname = patient.firstname;
            //newPatientModel.lastname = patient.lastname;
            //newPatientModel.departmentid = patient.departmentid;


            //string dob = patient.dob;
            //newPatientModel.dob = dob;
            //newPatientModel.email = patient.email;


            ViewData["CalendlyUser"] = HttpContext.Session.GetString("CalendlyUser");
            // Get access code
            var accessToken = await _athenaAuth.Token();


            // get PracticedId
            var practicedId = _athenaAuth.PracticedId();
            // API endpoint
            var apiEndpoint = _athenaAuth.APIEndpoint();
            var apiVersion = _athenaAuth.APIVersion();
            // 
            var authAPI = apiEndpoint + apiVersion + "/" + practicedId + "/patients";
            Dictionary<string, string> parameters = DictionaryData.ConvertToDictionary(patient);

            var responce = await _apiService.AthenaPostAsync(authAPI, parameters, accessToken);

            return View();
        }
    }
}
