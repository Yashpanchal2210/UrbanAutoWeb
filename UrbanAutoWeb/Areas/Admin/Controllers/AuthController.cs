using Microsoft.AspNetCore.Mvc;

namespace UrbanAutoWeb.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
