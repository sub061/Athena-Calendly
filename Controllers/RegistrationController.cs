using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Athena_Calendly.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordEncryption _passwordEncryption;
        private readonly ApiService _apiService;
        private readonly ICalendlyAuth _calendlyAuth;
        private readonly ICalendly _calendly;

        public RegistrationController(IUnitOfWork unitOfWork, IPasswordEncryption passwordEncryption, ApiService apiService, ICalendlyAuth calendlyAuth, ICalendly calendly)
        {
            _unitOfWork = unitOfWork;
            _passwordEncryption = passwordEncryption;
            _apiService = apiService;
            _calendlyAuth = calendlyAuth;
            _calendly = calendly;
        }

        public IActionResult Index(string app)
        {
            if (app == "nihar")
            {
                HttpContext.Session.SetString("CalendlyUser", "nihar");
            }
            else if (app == "hirsch")
            {
                HttpContext.Session.SetString("CalendlyUser", "hirsch");
            }
            else
            {
                HttpContext.Session.SetString("CalendlyUser", "webcontentor");
                app = "webcontentor";
            }
            ViewData["CalendlyUser"] = app.Trim();
            return View();
        }

        public async Task<IActionResult> Register(User user)
        {
            try
            {
                // Create hash Value to password text
                var hashPassword = _passwordEncryption.EncryptPassword(user.Password);
                user.Password = hashPassword;

                // Save user registration
                _unitOfWork.Users.PostRegistration(user);
                _unitOfWork.Save();

                // store user email
                HttpContext.Session.SetString("UserEmail", user.Email);

                // get calendly user
                var calendlyUser = HttpContext.Session.GetString("CalendlyUser");

                // Get Personal token

                string clientToken = _calendlyAuth.ClientPersonalToken(calendlyUser);
                HttpContext.Session.SetString("CalendlyAccessToken", clientToken);

                await _calendly.SetCalendlySession();

                return RedirectToAction("Dashboard", "Home");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
