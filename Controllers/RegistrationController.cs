using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.Models;
using Medical_Athena_Calendly.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using NuGet.Common;

namespace Medical_Athena_Calendly.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordEncryption _passwordEncryption;
        private readonly ApiService _apiService;
        private readonly ICalendlyAuth _calendlyAuth;

        public RegistrationController(IUnitOfWork unitOfWork , IPasswordEncryption passwordEncryption, ApiService apiService, ICalendlyAuth calendlyAuth)
        {
            _unitOfWork = unitOfWork;
            _passwordEncryption = passwordEncryption;
            _apiService = apiService;
            _calendlyAuth = calendlyAuth;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(User user)
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
                HttpContext.Session.SetString("userEmail", user.Email);
                return RedirectToAction("Dashboard", "Home");
               // return RedirectToAction("GetCalendlyAuthorize", "Calendly");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
