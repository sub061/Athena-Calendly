using Medical_Athena_Calendly.Interface;

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
        //public string ClientId()
        //{
        //    string clientId = _configuration.GetValue<string>("CalendlyClientId");
        //    return clientId;
        //}

        public string ClientPersonalToken(string app)
        {
            var key = "";
            if (app == "nihar")
            {
                key = "NiharCalendlyToken";
            }
            else if (app == "hirsch")
            {
                key = "HirschCalendlyToken";
            }
            else
            {
                key = "CalendlyToken";
            }
            string token = _configuration.GetValue<string>(key);
            return token;
        }




        public string ClientTokenSecret()
        {
            throw new NotImplementedException();
        }


    }
}
