namespace Medical_Athena_Calendly.Interface
{
    public interface ICalendlyAuth
    {
        //public string ClientId();
        //public string ClientSecret();
        //public string ReturnUrl();
        //public string ClientToken();
        public string ClientPersonalToken(string app);
    }
}
