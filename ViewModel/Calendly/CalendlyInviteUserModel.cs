namespace Medical_Athena_Calendly.ViewModel.Calendly
{
    public class CalendlyInviteUserModel
    {
        public string email { get; set; }
    }

    public class CalendlyInviteUserOutputModel
    {
        public CalendlyInviteUserOutputResource resource  { get; set; }
    }
    public class CalendlyInviteUserOutputResource
    {
        public string uri { get; set; }
        public string organization { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string last_sent_at { get; set; }
        public string user { get; set; }
    }
}
