using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UrbanAutoWeb.Controllers
{
    public class MainScreenController : Controller
    {
        //[Authorize]
        public IActionResult Home()
        {
            return View();
        }
    }
}
