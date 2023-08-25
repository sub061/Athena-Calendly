using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.ViewModel;
using Medical_Athena_Calendly.ViewModel.Athena;

namespace Medical_Athena_Calendly.Repository
{
    public class AthenaAuth : IAthenaAuth
    {
        private IConfiguration _configuration;
        private readonly ApiService _apiService;
        private readonly IUnitOfWork _unitOfWork;
        public AthenaAuth(IConfiguration configuration1, ApiService apiService, IUnitOfWork unitOfWork)
        {
            _configuration = configuration1;
            _apiService = apiService;
            _unitOfWork = unitOfWork;
        }

        // Get athena clientid value from appsetting
        public string APIEndpoint()
        {
            string url = _configuration.GetValue<string>("AthenaApi");
            return url;
        }
        public string APIVersion()
        {
            string version = _configuration.GetValue<string>("AthenaVersion");
            return version;
        }
        public string PracticedId()
        {
            string practiceId = _configuration.GetValue<string>("AthenaPracticedId");
            return practiceId;
        }
        public int DepartmentId(string app)
        {
            var key = "";
            if (app == "nihar")
            {
                key = "NiharDepartmentId";
            }
            else if (app == "hirsch")
            {
                key = "HirschDepartmentId";
            }

            int token = _configuration.GetValue<int>(key);
            return token;
        }

        public async Task<string> Token()
        {
            Dictionary<string, string> request = new Dictionary<string, string>
            {
                {"grant_type","client_credentials"},
                {"scope", Scope() }
            };

            // Get Header Authrization value
            var clientTokan = ClientToken();

            // Get api endpoint
            var apiEndpoint = APIEndpoint();
            var apiVersion = APIVersion();
            var authAPI = apiEndpoint + "oauth2/" + apiVersion + "/token";

            // Make the API POST call for Get Access Token
            var response = await _apiService.PostAsync<AthenaTokanResponseModel>(authAPI, request, clientTokan);


            return response.access_token;
        }

        // Get athena clientid value from appsetting
        public string ClientId()
        {
            string clientId = _configuration.GetValue<string>("AthenaClientId");
            return clientId;
        }
        // Get athena clientsecret value from appsetting
        public string ClientSecret()
        {
            string clientSecret = _configuration.GetValue<string>("AthenaSecretId");
            return clientSecret;
        }
        // Get athena scope value from appsetting
        public string Scope()
        {
            string clientSecret = _configuration.GetValue<string>("AthenaScope");
            return clientSecret;
        }
        // Get athena client token which provide in header 
        public string ClientToken()
        {
            string clientId = ClientId();
            string clientSecret = ClientSecret();
            var clientToken = Encryption.ConvertToBase64(clientId + ":" + clientSecret);
            return clientToken;
        }

        public async Task<string> GetBaseUrl()
        {
            var accessToken = await Token();


            // get PracticedId
            var practicedId = PracticedId();
            // API endpoint
            var apiEndpoint = APIEndpoint();
            var apiVersion = APIVersion();
            // 
            var authAPI = apiEndpoint + apiVersion + "/" + practicedId + "/";
            return authAPI;

        }

        public async Task<PatientSearchVM> PatientSearch(string email, int departmentId, string dob)
        {
            var accessToken = await Token();
            // Get base url
            var url = await GetBaseUrl();

            var authAPI = url + "/patients?email=" + email + "&departmentid=" + departmentId + "@dob=" + dob;

            var responce = await _apiService.GetAsync<PatientSearchVM>(authAPI, accessToken);

            return responce;

        }
        public async Task<int> CreateDefaultPatientRegistration(int id, int departmentId)
        {
            var user = _unitOfWork.Users.FindByCondition(m => m.Id == id).FirstOrDefault();
            NewPatientModel model = new NewPatientModel();
            model.firstname = user.FirstName;
            model.lastname = user.LastName;
            model.dob = user.DOB;
            model.email = user.Email;
            model.departmentid = departmentId;
            var response = await Registration(model);
            return 1;
        }
        public async Task<int> Registration(NewPatientModel model)
        {
            var accessToken = await Token();
            // Get base url
            var url = await GetBaseUrl();
            var authAPI = url + "patients";
            Dictionary<string, string> parameters = DictionaryData.ConvertToDictionary(model);

            var responce = await _apiService.AthenaPostAsync(authAPI, parameters, accessToken);

            return 1;
        }
    }
}
