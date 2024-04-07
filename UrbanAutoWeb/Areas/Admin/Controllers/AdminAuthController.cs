using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UrbanAutoWeb.Service.Models;
using UrbanAutoWeb.Service.Service.SuperAdmin;

namespace UrbanAutoWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAuthController : Controller
    {
        #region Fields
        private readonly ISuperAdminRepository _SuperAdminRepository;
        private readonly IMapper _mapper;

        [TempData]
        public string AlertMessage { get; set; }
        #endregion

        #region Ctor
        public AdminAuthController(ISuperAdminRepository superAdminRepository, IMapper mapper)
        {
            _SuperAdminRepository = superAdminRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public IActionResult Login(string ReturnUrl = "")
        {
            SuperAdminViewModel loginViewModel = new SuperAdminViewModel();
            loginViewModel.ReturnUrl = ReturnUrl;
            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Login(SuperAdminViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            if (!string.IsNullOrEmpty(loginViewModel.UserName) && !string.IsNullOrEmpty(loginViewModel.Password))
            {
                var result = _SuperAdminRepository.Authenticate(loginViewModel.UserName, loginViewModel.Password);

                if (result == true)
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, loginViewModel.UserName) },
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    HttpContext.Session.SetString("username", loginViewModel.UserName);
                    HttpContext.Session.SetString("isUserLogged", "True");

                    AlertMessage = "You have been successfully logged in";

                    if (!String.IsNullOrEmpty(loginViewModel.ReturnUrl))
                    {
                        return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
                    }
                }
            }
            loginViewModel.ErrorMsg = "Please enter valid credentials";
            return View(loginViewModel);
        }
        #endregion
    }
}
