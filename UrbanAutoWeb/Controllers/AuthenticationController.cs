using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UrbanAutoWeb.Service.Models;
using UrbanAutoWeb.Service.Service.SuperAdmin;
using AutoMapper;

namespace UrbanAutoWeb.Controllers
{
    public class AuthenticationController : Controller
    {

        #region Fields
        private readonly ISuperAdminRepository _SuperAdminRepository;
        private readonly IMapper _mapper;

        [TempData]
        public string AlertMessage { get; set; }
        #endregion

        #region Ctor
        public AuthenticationController(ISuperAdminRepository superAdminRepository, IMapper mapper)
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
            
            return View(loginViewModel);
        }
        #endregion
    }
}
