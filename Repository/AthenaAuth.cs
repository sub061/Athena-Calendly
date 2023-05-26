using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;

namespace Medical_Athena_Calendly.Repository
{
    public class AthenaAuth: IAthenaAuth
    {
        private IConfiguration _configuration;
        public AthenaAuth(IConfiguration configuration1)
        {
            _configuration = configuration1;
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
    }
}
