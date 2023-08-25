using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add Provider
var provider = builder.Services.BuildServiceProvider();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
  .AddCookie()
  .AddGoogle(options =>
  {
      options.ClientId = "963608127901-m96s4i9oji19olc7hghqn3vllr2tp3us.apps.googleusercontent.com";
      options.ClientSecret = "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";
  });

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
builder.Services.AddDbContext<ApplicationDBContext>
    (options => options.UseNpgsql(builder.Configuration.GetConnectionString("MedicalDb")));
//builder.Services.AddDbContext<ApplicationDBContext>
//    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalDb")));




var app = builder.Build();

var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());



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
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Login}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{app=nihar}/{action=Index}");
app.Run();
