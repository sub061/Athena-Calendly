namespace Medical_Athena_Calendly.Interface
{
    public interface IAthenaAuth
    {
        public string APIEndpoint();
        public string APIVersion();
        public string PracticedId();
        public string ClientId();
        public string ClientSecret();
        public string Scope();
        public string ClientToken();
    }
}
