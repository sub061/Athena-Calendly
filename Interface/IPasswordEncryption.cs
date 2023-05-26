namespace Medical_Athena_Calendly.Interface
{
    public interface IPasswordEncryption
    {
        string EncryptPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
        string CalendlyAuthorizationHeader();
    }
}
