namespace Medical_Athena_Calendly.ViewModel.Calendly
{
 


    public class QuestionAndAnswer
    {
        public string answer { get; set; }
        public int position { get; set; }
        public string question { get; set; }
    }

    public class Tracking
    {
        public object utm_campaign { get; set; }
        public object utm_source { get; set; }
        public object utm_medium { get; set; }
        public object utm_content { get; set; }
        public object utm_term { get; set; }
        public object salesforce_uuid { get; set; }
    }

    public class Payment
    {
        public string external_id { get; set; }
        public string provider { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
        public string terms { get; set; }
        public bool successful { get; set; }
    }

    public class Reconfirmation
    {
        public DateTime created_at { get; set; }
        public DateTime confirmed_at { get; set; }
    }

    public class CancleAndRescheduleLinkModelInvitee
    {
        public string cancel_url { get; set; }
        public DateTime created_at { get; set; }
        public string email { get; set; }
        public string @event { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public object new_invitee { get; set; }
        public object old_invitee { get; set; }
        public List<QuestionAndAnswer> questions_and_answers { get; set; }
        public string reschedule_url { get; set; }
        public bool rescheduled { get; set; }
        public string status { get; set; }
        public object text_reminder_number { get; set; }
        public string timezone { get; set; }
        public Tracking tracking { get; set; }
        public DateTime updated_at { get; set; }
        public string uri { get; set; }
        public bool canceled { get; set; }
        public string routing_form_submission { get; set; }
        public Payment payment { get; set; }
        public object no_show { get; set; }
        public Reconfirmation reconfirmation { get; set; }
    }

    public class CancleAndRescheduleLinkModelPagination
    {
        public int count { get; set; }
        public string next_page { get; set; }
        public string previous_page { get; set; }
        public string next_page_token { get; set; }
        public string previous_page_token { get; set; }
    }

    public class CancleAndRescheduleLinkModel
    {
        public List<CancleAndRescheduleLinkModelInvitee> collection { get; set; }
        public CancleAndRescheduleLinkModelPagination pagination { get; set; }
    }
}
