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
        public LoginController(IPasswordEncryption passwordEncryption, IUser user)
        {
            _passwordEncryption = passwordEncryption;
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(User user)
        {
            HttpContext.Session.Clear();

            // Create hash Value to password text
            var hashPassword = _passwordEncryption.EncryptPassword(user.Password);
            var userDetails = _user.FindByCondition(m => m.Email == user.Email && m.Password == hashPassword).FirstOrDefault();

            if (userDetails == null)
            {
                return View("Index");
            }

            // Set Session
            HttpContext.Session.SetString("userName", userDetails.Name);
            HttpContext.Session.SetString("userEmail", userDetails.Email);
            return RedirectToAction("Dashboard", "Home");

            // return RedirectToAction("CalendlyLogin", "Calendly");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }

    }
}
