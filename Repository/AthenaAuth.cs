using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Athena_Calendly.Repository
{
    public class AthenaAuth: IAthenaAuth
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private IConfiguration _configuration;
        private readonly ApiService _apiService;
        public AthenaAuth(IConfiguration configuration1, ApiService apiService, IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration1;
            _apiService = apiService;
            _contextAccessor = contextAccessor;
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


        public async Task Authentication()
        {
            var session = _contextAccessor.HttpContext.Session;
            // Create request object
            //AthenaTokanRequestModel request = new AthenaTokanRequestModel();
            //request.grant_type = "client_credentials";
            //request.scope = _athenaAuth.Scope();

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

            // Store and retrieve access token in session
            session.SetString("athena_access_token", response.access_token);
            
        }
    }
}
