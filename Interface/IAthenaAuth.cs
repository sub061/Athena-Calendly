using Medical_Athena_Calendly.ViewModel.Athena;

namespace Medical_Athena_Calendly.Interface
{
    public interface IAthenaAuth
    {
        Task<PatientSearchVM> PatientSearch(string email, int departmentId, string dob);
        Task<int> CreateDefaultPatientRegistration(int id, int departmentId);
        Task<string> GetBaseUrl();
        Task<int> Registration(NewPatientModel model);
        public string APIEndpoint();
        int DepartmentId(string app);
        public string APIVersion();
        public string PracticedId();
        public string ClientId();
        public string ClientSecret();
        public string Scope();
        public string ClientToken();

        Task<string> Token();
    }
}
