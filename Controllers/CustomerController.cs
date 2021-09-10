using FOODEE.Interface;
using FOODEE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMenuItemService _menuitemService;
        private readonly IMenuService _menuService;
        private readonly IMenuMenuItemService _menumenuitemService;

        public CustomerController(IMenuItemService menuitemService, IMenuService menuService, IMenuMenuItemService menumenuitemService)
        {
            _menuitemService = menuitemService;
            _menuService = menuService;
            _menumenuitemService = menumenuitemService;
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
    }
}
