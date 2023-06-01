using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Medical_Athena_Calendly.ViewModel.Calendly
{
    public class CalendlyInvitation
    {
    
        public Invitation[] collection { get; set; }

    
        public Pagination pagination { get; set; }
    }
    public class Invitation
    {

        public DateTime created_at { get; set; }


        public string email { get; set; }

        public DateTime last_sent_at { get; set; }


        public string organization { get; set; }

  
        public string status { get; set; }


        public DateTime updated_at { get; set; }


        public string uri { get; set; }

        public string user { get; set; }
    }

    public class Pagination
    {

        public int count { get; set; }


        public object next_page { get; set; }


        public object next_page_token { get; set; }


        public object previous_page { get; set; }


        public object previous_page_token { get; set; }
    }


}
