using Microsoft.Build.Framework;

namespace Medical_Athena_Calendly.ViewModel
{
    public class AccessTokensRequestModel
    {
        [Required]
        public string grant_type { get; set; }
        [Required]
        public string code { get; set; }
        [Required]
        public string redirect_uri { get; set; }
    }

    public class AthenaTokanRequestModel
    {
        public string grant_type { get; set; }
        public string scope { get; set; }
    }

    public class AthenaTokanResponseModel
    {
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string access_token { get; set; }
        public string scope { get; set; }
    }
}
