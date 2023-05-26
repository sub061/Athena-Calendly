using Microsoft.Build.Framework;

namespace Medical_Athena_Calendly.ViewModel.Calendly
{

    public class CalendlyUserModel
    {
       public Resource resource { get; set; }
    }

    public class Resource
    {
        [Required]
        public string uri { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string slug { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string scheduling_url { get; set; }
        [Required]
        public string timezone { get; set; }
        [Required]
        public string avatar_url { get; set; }
        [Required]
        public string created_at { get; set; }
        [Required]
        public string updated_at { get; set; }
        [Required]
        public string current_organization { get; set; }
    }
}
