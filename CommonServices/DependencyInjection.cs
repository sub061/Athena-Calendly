using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.Repository;

namespace Medical_Athena_Calendly.CommonServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {

            services.AddScoped<IUser, UserRepo>();
            services.AddScoped<IPasswordEncryption, PasswordEncryptionRepo>();
            services.AddScoped<ICalendlyAuth, CalendlyAuth>();
            services.AddScoped<ICalendly, Calendly>();
            services.AddScoped<IAthenaAuth, AthenaAuth>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<EmailSender>();


            return services;

        }
    }
}
