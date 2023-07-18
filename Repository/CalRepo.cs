using Medical_Athena_Calendly.Interface;

namespace Medical_Athena_Calendly.Repository
{
    
    public class CalRepo  : ICal
    {
        private IConfiguration _configuration;

        public CalRepo(IConfiguration configuration1)
        {
            _configuration = configuration1;
        }

        public string CalKey()
    {
        string clientId = _configuration.GetValue<string>("CalLiveKey");
        return clientId;
    }
}

    
}
