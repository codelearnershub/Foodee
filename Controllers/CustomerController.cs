using FOODEE.DTO;
using FOODEE.Interface;
using FOODEE.Models;
using FOODEE.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FOODEE.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMenuItemService _menuitemService;
        private readonly IMenuService _menuService;
        private readonly IMenuMenuItemService _menumenuitemService;
        public IUserService _userService;
        public IUserRoleService _userRoleService;
        public IRoleService _roleService;

        public CustomerController(IMenuItemService menuitemService, IMenuService menuService, IMenuMenuItemService menumenuitemService, IUserService userService, IUserRoleService userRoleService, IRoleService roleService)
        {
            _menuitemService = menuitemService;
            _menuService = menuService;
            _menumenuitemService = menumenuitemService;
            _userService = userService;
            _userRoleService = userRoleService;
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            return View(_menuService.GetAll());
        }
        [HttpGet]
        public IActionResult GetByMenu(int id)
        {

            var menumenuItem = _menumenuitemService.GetByMenu(id);

            ViewBag.Menu = _menuService.FindById(id).Name;

            List<MenuItem> MenuItems = new List<MenuItem>();
            foreach (var item in menumenuItem)
            {
                var menuitem = _menuitemService.FindById(item.MenuItemId);
                MenuItems.Add(menuitem);
            }

            return View(MenuItems);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel vm, bool isCheckout = false)
        {
            CreateUserDto createuserDto = new CreateUserDto
            {
                Email = vm.Email,
                Password = vm.Password,
            };
            User user = _userService.LoginUser(createuserDto);
            if (user == null)
            {
                if (isCheckout)
                {
                    return RedirectToAction("Checkout","Order");
                }
                return View();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "Customer")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var props = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
                return isCheckout ? RedirectToAction("Checkout", "Order") : RedirectToAction("Index", "Home");
            }
        }
    }   
}
    

