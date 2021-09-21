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
        public readonly IUserService _userService;
        public readonly ICartService _cartService;

        public CustomerController(IMenuItemService menuitemService, IMenuService menuService, IMenuMenuItemService menumenuitemService, IUserService userService, IUserRoleService userRoleService, IRoleService roleService,ICartService cartService)
        {
            _menuitemService = menuitemService;
            _menuService = menuService;
            _menumenuitemService = menumenuitemService;
            _userService = userService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View(_menuService.GetAll());
        }
        [HttpGet]
        //public IActionResult GetByMenu(int id)
        //{

        //    var menumenuItem = _menumenuitemService.GetByMenu(id);

        //    ViewBag.Menu = _menuService.FindById(id).Name;

        //    List<MenuItem> MenuItems = new List<MenuItem>();
        //    foreach (var item in menumenuItem)
        //    {
        //        var menuitem = _menuitemService.FindById(item.MenuItemId);
        //        MenuItems.Add(menuitem);
        //    }

        //    return View(MenuItems);
        //}
        public IActionResult CustomerIndex()
        {
            var model = new HomeVM.IndexAnonymous
            {
                MenuItems = _menuitemService.GetAll(),
                NumberOfCartItems = (User.Identity.IsAuthenticated && User.IsInRole("customer"))
                    ? _cartService.GetNumberOfCartItems(
                        Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                    : 0
            };
            return View(model);
        }
    }   
}
    

