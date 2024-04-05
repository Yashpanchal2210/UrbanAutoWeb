using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UrbanAutoWeb.Controllers
{
    public class WebPageController : Controller
    {
        [AllowAnonymous]
        public IActionResult Home()
        {
            return View();
        }
    }
}
