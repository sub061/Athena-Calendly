using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Athena_Calendly.Controllers
{
	public class AuthController : Controller
	{
        [HttpGet]
        public IActionResult Calendly()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("ExternalCallbackAsync" ,"Calendly")
            };

            return Challenge(properties, "Calendly");
        }

        [HttpGet]
        public IActionResult Callback()
        {
            // Handle the callback action if needed

            return RedirectToAction("Dashboard", "Home");
        }
    }
}
