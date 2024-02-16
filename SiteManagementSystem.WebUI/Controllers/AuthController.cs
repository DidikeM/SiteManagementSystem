using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagementSystem.Business.Abstract;
using SiteManagementSystem.Entities.Concrete;
using SiteManagementSystem.WebUI.DTOs;
using System.Security.Claims;

namespace SiteManagementSystem.WebUI.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService, IMapper mapper)
        {
            _mapper = mapper;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = _authService.Login(userLoginDto.Username, userLoginDto.Password);
            if (user != null)
            {
                var claims = new List<Claim>
                    {
                        new("Id", user.Id.ToString()),
                        new("Username", user.Username),
                        new("IsAdmin", user.IsAdmin.ToString())
                    };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                var claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterDto userRegisterDto)
        {
            var user = _mapper.Map<User>(userRegisterDto);
            _authService.Register(user!);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}
