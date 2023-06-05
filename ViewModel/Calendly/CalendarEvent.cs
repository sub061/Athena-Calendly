namespace Medical_Athena_Calendly.ViewModel.Calendly
{
    public class CalendarEvent
    {
        public string external_id { get; set; }
        public string kind { get; set; }
    }

    public class EventGuest
    {
        public DateTime created_at { get; set; }
        public string email { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class EventMembership
    {
        public string user { get; set; }
        public string user_email { get; set; }
    }

    public class InviteesCounter
    {
        public int active { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
    }

    public class Location
    {
        public object location { get; set; }
        public string type { get; set; }
    }

    public class Event
    {
        public CalendarEvent calendar_event { get; set; }
        public DateTime created_at { get; set; }
        public DateTime end_time { get; set; }
        public List<EventGuest> event_guests { get; set; }
        public List<EventMembership> event_memberships { get; set; }
        public string event_type { get; set; }
        public InviteesCounter invitees_counter { get; set; }
        public Location location { get; set; }
        public string name { get; set; }
        public DateTime start_time { get; set; }
        public string status { get; set; }
        public DateTime updated_at { get; set; }
        public string uri { get; set; }
    }

    public class CalenderEventPagination
    {
        public int count { get; set; }
        public object next_page { get; set; }
        public object next_page_token { get; set; }
        public object previous_page { get; set; }
        public object previous_page_token { get; set; }
    }

    public class AppointmentsForPaitientRoot
    {
        public List<Event> collection { get; set; }
        public CalenderEventPagination pagination { get; set; }
    }
}
