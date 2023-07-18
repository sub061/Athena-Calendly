namespace Medical_Athena_Calendly.ViewModel.CalCom
{
    public class CalMembership
    {
        public List<MembershipViewModel> memberships { get; set; }
    }

    public class MembershipViewModel
    {
        public int id { get; set; }
        public int teamId { get; set; }
        public int userId { get; set; }
        public bool accepted { get; set; }
        public string role { get; set; }
        public bool disableImpersonation { get; set; }
        public TeamViewModel team { get; set; }
    }

    public class TeamViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string logo { get; set; }
        public string appLogo { get; set; }
        public string appIconLogo { get; set; }
        public string bio { get; set; }
        public bool hideBranding { get; set; }
        public bool isPrivate { get; set; }
        public bool hideBookATeamMember { get; set; }
        public DateTime createdAt { get; set; }
        public MetadataViewModel metadata { get; set; }
        public string theme { get; set; }
        public string brandColor { get; set; }
        public string darkBrandColor { get; set; }
        public int? parentId { get; set; }
        public string timeFormat { get; set; }
        public string timeZone { get; set; }
        public string weekStart { get; set; }
    }

    public class MetadataViewModel
    {
        public string requestedSlug { get; set; }
    }

}
