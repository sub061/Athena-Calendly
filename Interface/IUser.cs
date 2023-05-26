using Medical_Athena_Calendly.Models;

namespace Medical_Athena_Calendly.Interface
{
    public interface IUser : IGeneric<User>
    {
        void PostRegistration(User user);
    }
}
