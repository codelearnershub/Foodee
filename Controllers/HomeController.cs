using FOODEE.Interface;
using FOODEE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuItemService _menuitemService;

        public HomeController(IMenuItemService menuitemService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _menuitemService = menuitemService;
        }
        public IActionResult Index()
        {
            var menuitems = _menuitemService.GetAll();
            return View(menuitems);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string search)
        {
            IEnumerable<MenuItem> menuitems = _menuitemService.Search(search);
            return View("Index", menuitems);
        }
        public IActionResult ViewCart()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
