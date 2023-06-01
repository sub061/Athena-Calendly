namespace Medical_Athena_Calendly.ViewModel.Calendly
{
    public class AppointmentResponseLocation
    {
        public string Type { get; set; }
        public string LocationName { get; set; }
    }

    public class AppointmentResponseInviteesCounter
    {
        public int Total { get; set; }
        public int Active { get; set; }
        public int Limit { get; set; }
    }

    public class AppointmentResponseEventMembership
    {
        public string User { get; set; }
        public string UserEmail { get; set; }
    }

    public class AppointmentResponseEventGuest
    {
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class AppointmentResponseScheduledEvent
    {
        public string Uri { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EventType { get; set; }
        public AppointmentResponseLocation Location { get; set; }
        public AppointmentResponseInviteesCounter InviteesCounter { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<AppointmentResponseEventMembership> EventMemberships { get; set; }
        public List<AppointmentResponseEventGuest> EventGuests { get; set; }
    }

    public class AppointmentResponsePagination
    {
        public int Count { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }
        public string NextPageToken { get; set; }
        public string PreviousPageToken { get; set; }
    }

    public class AppointmentResponseEventCollection
    {
        public List<AppointmentResponseScheduledEvent> Collection { get; set; }
        public AppointmentResponsePagination Pagination { get; set; }
    }

    public class AppointmentResponse
    {
        public AppointmentResponseEventCollection EventCollection { get; set; }
    }
}
