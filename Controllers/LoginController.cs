using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.Models;
using Medical_Athena_Calendly.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Athena_Calendly.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPasswordEncryption _passwordEncryption;
        private readonly IUser _user;
        private readonly ICalendly _calendly;
        private readonly ICalendlyAuth _calendlyAuth;
        private readonly ILogger<LoginController> logger;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IPasswordEncryption passwordEncryption, IUser user, ICalendly calendly, ICalendlyAuth calendlyAuth, ILogger<LoginController> logger, IUnitOfWork unitOfWork)
        {
            _passwordEncryption = passwordEncryption;
            _user = user;
            _calendly = calendly;
            _calendlyAuth = calendlyAuth;
            this.logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("login/{app}")]
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
            return View();
        }
        [HttpPost]
        [Route("login/{app}")]
        public async Task<IActionResult> Login(string app, User user)
        {
            HttpContext.Session.Clear();
            var calendlyUser = TempData["CalendlyUser"] as string;
            HttpContext.Session.SetString("CalendlyUser", calendlyUser);

            //Create hash Value to password text
            var hashPassword = _passwordEncryption.EncryptPassword(user.Password);
            var userDetails = _user.FindByCondition(m => m.Email == user.Email && m.Password == hashPassword).ToList();
            if (userDetails == null)
            {
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View("Index", user);
            }

            // Set Session
            HttpContext.Session.SetString("UserName", userDetails[0].Name);
            HttpContext.Session.SetString("UserEmail", userDetails[0].Email);


            //Get Personal token
            string clientToken = _calendlyAuth.ClientPersonalToken(calendlyUser);
            HttpContext.Session.SetString("CalendlyAccessToken", clientToken);
            await _calendly.SetCalendlySession();

            logger.LogInformation("API started at:" + DateTime.Now);
            return RedirectToAction("Dashboard", "Home", app);
            //return RedirectToRoute("/dashboard/" + app);
        }


        public IActionResult Logout()
        {
            var app = HttpContext.Session.GetString("CalendlyUser");
            //HttpContext.Session.Clear();
            // for google
            //return SignOut(CookieAuthenticationDefaults.AuthenticationScheme);
            //return RedirectToAction("Index", app);
            return RedirectToRoute(app + "/login");
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
        public IActionResult ChangePassword()
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
