namespace Medical_Athena_Calendly.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUser Users { get;}
        void Save();
    }
} 
