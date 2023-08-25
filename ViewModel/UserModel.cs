namespace Medical_Athena_Calendly.ViewModel
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpiration { get; set; }
    }
}
