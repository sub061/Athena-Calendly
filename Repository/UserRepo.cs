using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.Models;
using System.Runtime.CompilerServices;

namespace Medical_Athena_Calendly.Repository
{
    public class UserRepo : GenericRepository<User> , IUser
    {
        private ApplicationDBContext _dbContext;
        public UserRepo(ApplicationDBContext dbContext): base(dbContext) {
            _dbContext = dbContext;
        }
        public void PostRegistration(User user)
        {
            user.CreatedDate = DateTime.UtcNow;
            user.UpdatedDate = DateTime.UtcNow;
            _dbContext.Add(user);
        }
    }
}
