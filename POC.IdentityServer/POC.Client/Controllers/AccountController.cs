using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace POC.Client.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        [Authorize]
        public IActionResult Secure()
        {
            return View();
        }
    }
}
