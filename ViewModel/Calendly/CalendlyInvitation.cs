using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Medical_Athena_Calendly.ViewModel.Calendly
{
    public class CalendlyInvitation
    {
        [JsonProperty("collection")]
        public Invitation[] Collection { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
    public class Invitation
    {
        [JsonProperty("created_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("last_sent_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime LastSentAt { get; set; }

        [JsonProperty("organization")]
        public string Organization { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("updated_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class Pagination
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next_page")]
        public object NextPage { get; set; }

        [JsonProperty("next_page_token")]
        public object NextPageToken { get; set; }

        [JsonProperty("previous_page")]
        public object PreviousPage { get; set; }

        [JsonProperty("previous_page_token")]
        public object PreviousPageToken { get; set; }
    }


}
