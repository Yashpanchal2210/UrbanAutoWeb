using Microsoft.AspNetCore.Mvc;

namespace UrbanAutoWeb.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
