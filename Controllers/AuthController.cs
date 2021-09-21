using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FOODEE.DTO;
using FOODEE.Interface;
using FOODEE.Models;
using FOODEE.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace FOODEE.Controllers
{
    public class AuthController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;

        // GET
        public AuthController(IRoleService roleService, IUserService userService, IUserRoleService userRoleService)
        {
            _roleService = roleService;
            _userService = userService;
            _userRoleService = userRoleService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AuthVM.CreateUser model)
        {
            var createuserDto = new CreateUserDto
            {
                CreatedAt = model.CreatedAt,
                LastName = model.LastName,
                FirstName = model.FirstName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Address = model.Address,
                Gender = model.Gender,
                Password = model.Password,
                RoleId = _roleService.FindByName("Customer").Id,
            };
            _userService.RegisterUser(createuserDto);
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthVM.LoginUser vm, string returnUrl)
        {
            var createuserDto = new CreateUserDto
            {
                Email = vm.Email,
                Password = vm.Password,
            };

            User user = _userService.LoginUser(createuserDto);

            if (user == null)
            {
                ViewBag.Message = "error";
                return View();
            }

            var role = _userRoleService.FindRole(user.Id);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var props = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
            
            if (returnUrl != null) return Redirect(returnUrl);

            return role switch
            {
                "superadmin" => RedirectToAction("IndexAdmin", "Menu"),
                "admin" => RedirectToAction("Index", "Admin"),
                "customer" => RedirectToAction("Index", "Customer"),
                _ => Unauthorized()
            };
        }

        public async Task<IActionResult> Logout()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";
        
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}