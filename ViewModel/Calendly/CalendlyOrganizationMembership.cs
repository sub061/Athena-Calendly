namespace Medical_Athena_Calendly.ViewModel.Calendly
{
    public class CalendlyUser
    {
        public string uri { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string email { get; set; }
        public string scheduling_url { get; set; }
        public string timezone { get; set; }
        public string avatar_url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class OrganizationMembership
    {
        public string uri { get; set; }
        public string role { get; set; }
        public CalendlyUser user { get; set; }
        public string organization { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
    }

    public class OrganizationMembershipPagination
    {
        public int count { get; set; }
        public string next_page { get; set; }
        public string previous_page { get; set; }
        public string next_page_token { get; set; }
        public string previous_page_token { get; set; }
    }

    public class CalendlyOrganizationMembership
    {
        public List<OrganizationMembership> collection { get; set; }
        public OrganizationMembershipPagination pagination { get; set; }
    }
}
