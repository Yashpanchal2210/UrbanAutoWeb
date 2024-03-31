using Microsoft.AspNetCore.Mvc;
using UrbanAutoWeb.Service.Models;

namespace UrbanAutoWeb.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            return View();
        }
    }
}
