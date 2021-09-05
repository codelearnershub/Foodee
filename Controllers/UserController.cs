using FOODEE.DTO;
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
        public IUserRoleService _userRoleService;
        public IRoleService _roleService;

        public UserController(IUserService userService, IUserRoleService userRoleService, IRoleService roleService)
        {
            _userService = userService;

            _userRoleService = userRoleService;

            _roleService = roleService;
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
            var userDto = new CreateUserDto
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Address = model.Address,
                Gender = model.Gender,
                Password = model.Password
            };

            _userService.RegisterUser(userDto);
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm, bool isMenu = false)
        {
            User user = _userService.LoginUser(vm.Email, vm.Password);

            if (user == null) return View();

            var roles = _userRoleService.FindUserRoles(user.Id);

            var role = roles[0].Name;

            if (user == null)
            {
                ViewBag.Message = "Invalid Username/Password";
                if (isMenu)
                {
                    return RedirectToAction("Menu", "Order");
                }

            }
            else if (role == "SuperAdmin")
            {
               var claims = new List<Claim>
               {
                 new Claim(ClaimTypes.Name, $"{user.FirstName}"),
                 new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.Role, "SuperAdmin"),
               };
                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var props = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,props);
                return isMenu ? RedirectToAction("Menu", "Order") : RedirectToAction("Index", "SuperAdmin");
            }
            else if (role == "Admin")
            {
                var claims = new List<Claim>
               {
                 new Claim(ClaimTypes.Name, $"{user.FirstName}"),
                 new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.Role, "Admin"),
               };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var props = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
                return isMenu ? RedirectToAction("Menu", "Order") : RedirectToAction("Index", "Admin");
            }
            else if (role == "Customer")
            {
                var claims = new List<Claim>
               {
                 new Claim(ClaimTypes.Name, $"{user.FirstName}"),
                 new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.Role, "Customer"),
               };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var props = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
                return isMenu ? RedirectToAction("Menu", "Order") : RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
