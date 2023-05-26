namespace Medical_Athena_Calendly.ViewModel
{
    public class AccessTokensResponseModel
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public string created_at { get; set; }
        public string expires_in { get; set; }
        public string owner { get; set; }
        public string organization { get; set; }

    }
}
