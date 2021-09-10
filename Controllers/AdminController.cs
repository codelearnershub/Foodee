using FOODEE.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMenuItemService _menuitemService;

        public AdminController(IMenuItemService menuitemService)
        {
            _menuitemService = menuitemService;
        }

        public IActionResult Index()
        {
            return View(_menuitemService.GetAll());
        }
    }
}
