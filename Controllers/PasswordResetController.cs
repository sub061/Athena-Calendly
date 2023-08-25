using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Medical_Athena_Calendly.Controllers
{
    public class PasswordResetController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly EmailSender _emailSender;

        public PasswordResetController(ApplicationDBContext dbContext, EmailSender emailSender)
        {
            _dbContext = dbContext;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewData["CalendlyUser"] = HttpContext.Session.GetString("CalendlyUser");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            ViewData["CalendlyUser"] = HttpContext.Session.GetString("CalendlyUser");
            var user = _dbContext.users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                // Handle user not found
                return RedirectToAction("ForgotPassword");
            }


            // Generate reset token

            user.ResetToken = GenerateRandomToken();
            user.ResetTokenExpiration = DateTime.UtcNow.AddHours(1);

            await _dbContext.SaveChangesAsync();

            // Send reset password email
            // Implement your email sending logic here, for example, using SendGrid or SMTP

            string currentUrl = $"{Request.Scheme}://{Request.Host}";
            // Construct the reset link
            string resetLink = currentUrl + "PasswordReset/ResetPassword?token=" + user.ResetToken;

            // Compose the email body
            string emailBody = $"Click the link below to reset your password:\n\n{resetLink}";

            // Send the email
            bool isEmailSent = await _emailSender.SendEmailAsync(email, "Password Reset", emailBody);

            if (isEmailSent)
            {
                return RedirectToAction("ForgotPasswordConfirmation");
            }
            else
            {
                // Handle email sending failure
                return View("Error");
            }

            return RedirectToAction("ForgotPasswordConfirmation");
        }

        [HttpGet]
        public IActionResult ResetPassword(string token)
        {
            ViewData["CalendlyUser"] = HttpContext.Session.GetString("CalendlyUser");

            var user = _dbContext.users.FirstOrDefault(u => u.ResetToken == token && u.ResetTokenExpiration >= DateTime.UtcNow);
            if (user == null)
            {
                // Handle invalid or expired token
                return RedirectToAction("ForgotPassword");
            }

            ViewBag.Token = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string token, string newPassword)
        {
            ViewData["CalendlyUser"] = HttpContext.Session.GetString("CalendlyUser");
            var user = _dbContext.users.FirstOrDefault(u => u.ResetToken == token && u.ResetTokenExpiration >= DateTime.UtcNow);
            if (user == null)
            {
                // Handle invalid or expired token
                return RedirectToAction("ForgotPassword");
            }

            // Update password
            user.Password = HashPassword(newPassword);
            user.ResetToken = null;
            user.ResetTokenExpiration = null;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("ResetPasswordConfirmation");
        }

        private string GenerateRandomToken()
        {
            using var rng = new RNGCryptoServiceProvider();
            var tokenData = new byte[32];
            rng.GetBytes(tokenData);
            return Convert.ToBase64String(tokenData);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        public IActionResult ResetPasswordConfirmation()
        {
            ViewData["CalendlyUser"] = HttpContext.Session.GetString("CalendlyUser");
            return View();
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            ViewData["CalendlyUser"] = HttpContext.Session.GetString("CalendlyUser");
            return View();
        }
    }
}
