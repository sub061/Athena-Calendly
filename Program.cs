using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
// Add Provider
var provider = builder.Services.BuildServiceProvider();

// add for calendly

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = "Calendly";
})
        .AddCookie()
        .AddOAuth("Calendly", options =>
        {
            options.ClientId = "WyDfIWccnmIl2Hn_aCDlhbelxocevjroQB8nEqRfNsA";
            options.ClientSecret = "u-OZkauuDWKruBhfABpQ8fUG2pryCIc-qqhM4gCl4gA";
            options.CallbackPath = "/Calendly/ExternalCallbackAsync";

            options.AuthorizationEndpoint = "https://calendly.com/oauth/authorize";
            options.TokenEndpoint = "https://calendly.com/oauth/token";
            options.UserInformationEndpoint = "https://calendly.com/api/users/me";

            options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");

            options.Events = new OAuthEvents
            {
                OnCreatingTicket = context =>
                {
                    // Add additional claims if needed
                    // Example: context.Identity.AddClaim(new Claim(ClaimTypes.Email, context.User["email"].ToString()));

                    return Task.CompletedTask;
                }
            };
        });

// end calendly


// add Configuration
var configuration = provider.GetService<IConfiguration>();

// add session 
builder.Services.AddDistributedMemoryCache(); // Use an in-memory cache for storing session data
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true; // Set HttpOnly to help prevent cross-site scripting (XSS) attacks
    options.Cookie.IsEssential = true; // Make the session cookie essential to the application
    options.Cookie.Name = "SessionToken";
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set the session timeout
});


// Add Repository
builder.Services.AddRepository();

 builder.Services.AddHttpClient<ApiService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();




builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Add database connection
//builder.Services.AddDbContext<ApplicationDBContext>
//    (options => options.UseNpgsql(builder.Configuration.GetConnectionString("MedicalDb")));
builder.Services.AddDbContext<ApplicationDBContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalDb")));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();
app.UseAuthentication();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
