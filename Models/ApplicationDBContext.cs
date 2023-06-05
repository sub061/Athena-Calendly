using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Medical_Athena_Calendly.ViewModel.Athena;

namespace Medical_Athena_Calendly.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        { }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        { }

        // Table initialise

        public DbSet<User> users { get; set; } // for user credentials

        // Table initialise

        

    }
}
