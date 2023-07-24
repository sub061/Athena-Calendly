using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medical_Athena_Calendly.Models;
using Medical_Athena_Calendly.Interface;
using System.Net;

namespace Medical_Athena_Calendly.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPasswordEncryption _passwordEncryption;
        private readonly IUser _user;
        private readonly ICalendly _calendly;
        private readonly ICalendlyAuth _calendlyAuth;
        public LoginController(IPasswordEncryption passwordEncryption, IUser user, ICalendly calendly, ICalendlyAuth calendlyAuth)
        {
            _passwordEncryption = passwordEncryption;
            _user = user;
            _calendly = calendly;
            _calendlyAuth = calendlyAuth;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task< IActionResult> Login(User user)
        {
            HttpContext.Session.Clear();

            // Create hash Value to password text
            var hashPassword = _passwordEncryption.EncryptPassword(user.Password);
            var userDetails = _user.FindByCondition(m => m.Email == user.Email && m.Password == hashPassword).ToList();

            if (userDetails == null)
            {

                ViewBag.ErrorMessage = "Invalid email or password.";
               
                return View("Index" , user);
            }

            // Set Session
            HttpContext.Session.SetString("userName", userDetails[0].Name);
            HttpContext.Session.SetString("userEmail", userDetails[0].Email);
            // Get Personal token
            string clientToken = _calendlyAuth.ClientPersonalToken();
            HttpContext.Session.SetString("CalendlyAccessToken", clientToken);
            await _calendly.SetCalendlySession();
            
            return RedirectToAction("Dashboard", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }

    }
}
