using FOODEE.Interface;
using FOODEE.Models;
using FOODEE.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FOODEE.Controllers
{
    public class UserController : Controller
    {
        public IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(CreateUserViewModel model)
        {

            _userService.RegisterUser(model.Id, model.FirstName, model.LastName, model.Address, model.PhoneNumber, model.Email, model.Gender,model.Password);
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm, string FirstName, string LastName, string password, bool isMenu = false)
        {
            var user = _userService.LoginUser(vm.Email, vm.Password);

            if (user == null)
            {
                ViewBag.Message = "Invalid Username/Password";
                if (isMenu)
                {
                    return RedirectToAction("Menu", "Order");
                }
                return View();

            }
            else
            {
               var claims = new List<Claim>
               {
                 new Claim(ClaimTypes.Name, $"{user.FirstName}"),
                 new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.Role, "User"),
               };
                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var props = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,props);
                return isMenu ? RedirectToAction("Menu", "Order") : RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
