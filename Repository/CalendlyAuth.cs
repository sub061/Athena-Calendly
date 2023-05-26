using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Athena_Calendly.Repository
{
    public class CalendlyAuth : ICalendlyAuth
    {
        private IConfiguration _configuration;
        public CalendlyAuth(IConfiguration configuration1)
        {
            _configuration = configuration1;
        }

        // Get calendly clientid value from appsetting
        public string ClientId()
        {
            string clientId = _configuration.GetValue<string>("CalendlyClientId");
            return clientId;
        }
        // Get calendly clientsecret value from appsetting
        public string ClientSecret()
        {
            string clientSecret = _configuration.GetValue<string>("CalendlyClentSecret");
            return clientSecret;
        }
        // Get calendly return page url value from appsetting
        public string ReturnUrl()
        {
            string returnUrl = _configuration.GetValue<string>("CalendlyReturnUrl");
            return returnUrl;
        }
        // Get calendly client token which provide in header 
        public string ClientToken()
        {
            string clientId = ClientId();
            string clientSecret = ClientSecret();
            var clientToken = Encryption.ConvertToBase64(clientId + ":" + clientSecret);
            return clientToken;
        }
    }
}
