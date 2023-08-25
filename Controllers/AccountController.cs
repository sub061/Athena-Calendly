using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.Models;
using Medical_Athena_Calendly.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Athena_Calendly.Controllers
{
    [Route("account/{app}")]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordEncryption _passwordEncryption;
        private readonly ApiService _apiService;
        private readonly ICalendlyAuth _calendlyAuth;
        private readonly ICalendly _calendly;
        private readonly IUser _user;
        private readonly IAthenaAuth _athena;
        private readonly ILogger<AccountController> logger;


        public AccountController(IUnitOfWork unitOfWork, IPasswordEncryption passwordEncryption, ApiService apiService, ICalendlyAuth calendlyAuth, ICalendly calendly, IUser user, ILogger<AccountController> logger, IAthenaAuth athenaAuth)
        {
            _unitOfWork = unitOfWork;
            _passwordEncryption = passwordEncryption;
            _apiService = apiService;
            _calendlyAuth = calendlyAuth;
            _calendly = calendly;
            _user = user;
            _athena = athenaAuth;
            this.logger = logger;
        }

        [HttpGet]
        [Route("register")]
        public IActionResult Registration(string app)
        {
            // session value set for calendly user
            if (string.IsNullOrEmpty(app))
            {
                HttpContext.Session.SetString("CalendlyUser", "webcontentor");
                ViewData["CalendlyUser"] = "webcontentor";
            }
            else
            {

                HttpContext.Session.SetString("CalendlyUser", app);
                ViewData["CalendlyUser"] = app;
            }

            return View("Registration");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Registration(string app, User user)
        {
            try
            {
                // Create hash Value to password text
                var hashPassword = _passwordEncryption.EncryptPassword(user.Password);
                user.Password = hashPassword;

                // Save user registration
                _unitOfWork.Users.PostRegistration(user);
                _unitOfWork.Save();
                int departmentId = _athena.DepartmentId(app);

                await _athena.CreateDefaultPatientRegistration(user.Id, departmentId);

                // store user email
                HttpContext.Session.SetString("UserEmail", user.Email);

                // Get Personal token

                string clientToken = _calendlyAuth.ClientPersonalToken(app);
                HttpContext.Session.SetString("CalendlyAccessToken", clientToken);

                await _calendly.SetCalendlySession();

                return RedirectToAction("Dashboard", "Home", app);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        [Route("")]
        [Route("login")]
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
            TempData["CalendlyUser"] = app.Trim();
            return View("Login");
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string app, User user)
        {
            HttpContext.Session.Clear();
            var calendlyUser = TempData["CalendlyUser"] as string;
            HttpContext.Session.SetString("CalendlyUser", calendlyUser);

            //Create hash Value to password text
            var hashPassword = _passwordEncryption.EncryptPassword(user.Password);
            var userDetails = _user.FindByCondition(m => m.Email == user.Email && m.Password == hashPassword).ToList();
            if (userDetails.Count == 0)
            {
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View("Login", user);
            }

            // Set Session
            HttpContext.Session.SetString("UserName", userDetails[0].FirstName);
            HttpContext.Session.SetString("UserEmail", userDetails[0].Email);


            //Get Personal token
            string clientToken = _calendlyAuth.ClientPersonalToken(calendlyUser);
            HttpContext.Session.SetString("CalendlyAccessToken", clientToken);
            await _calendly.SetCalendlySession();

            logger.LogInformation("API started at:" + DateTime.Now);
            return RedirectToAction("Dashboard", "Home", app);
            //return RedirectToRoute("/dashboard/" + app);
        }

        public IActionResult Logout(string app)
        {

            HttpContext.Session.Clear();
            // for google
            //return SignOut(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account", app);

        }

        public IActionResult GoogleLogin()
        {
            string redirectUrl = Url.Action("GoogleResponse");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> GoogleResponse()
        {
            return RedirectToAction("Dashboard", "Home");
        }

        [HttpGet]
        [Route("change-password")]
        public IActionResult ChangePassword(string app)
        {
            ViewData["CalendlyUser"] = HttpContext.Session.GetString("CalendlyUser");
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            ViewData["CalendlyUser"] = HttpContext.Session.GetString("CalendlyUser");
            if (ModelState.IsValid)
            {
                var userEmail = HttpContext.Session.GetString("UserEmail");
                var hashPassword = _passwordEncryption.EncryptPassword(model.OldPassword);
                var user = _user.FindByCondition(m => m.Email == userEmail && m.Password == hashPassword).FirstOrDefault();

                if (user != null)
                {
                    var newHashPassword = _passwordEncryption.EncryptPassword(model.NewPassword);
                    user.Password = newHashPassword;
                    _user.Update(user);
                    _unitOfWork.Save();
                }

                return View(model);
            }
            return View(model);
        }


    }
}
