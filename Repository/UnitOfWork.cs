using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.Models;
using Microsoft.EntityFrameworkCore;

namespace Medical_Athena_Calendly.Repository
{
    public class UnitOfWork : IUnitOfWork
    { 
        private ApplicationDBContext _dbContext;

        private IUser _users;

        public UnitOfWork(ApplicationDBContext dbContext)
        {
            this._dbContext = dbContext;
           
        }

        public IUser Users
        {
            get 
            { 
                if(_users == null)
                {
                    return _users = new UserRepo(_dbContext);
                }
                return _users;
                
                 }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
