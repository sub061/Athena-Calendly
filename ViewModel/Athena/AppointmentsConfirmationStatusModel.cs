namespace Medical_Athena_Calendly.ViewModel.Athena
{
    public class AppointmentsConfirmationStatusModel
    {
        public List<Status> status { get; set; }
    }

    public class Status
    {
        public string name { get; set; }
        public int statusid { get; set; }
    }
}
