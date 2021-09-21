using FOODEE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FOODEE.Interface;

namespace FOODEE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuItemService _menuitemService;

        public HomeController(ILogger<HomeController> logger, IMenuItemService menuitemService)
        {
            _logger = logger;
            _menuitemService = menuitemService;
        }
        //public IActionResult Index()
        //{
        //    var menuitems = _menuitemService.GetAll();
        //    // return View(menuitems);

        //    return RedirectToAction("Index", "Home");
        //}
        public IActionResult Index()
        {
            var menuitems = _menuitemService.GetAll();
            // return View(menuitems);

            return RedirectToAction("IndexAnonymous", "MenuItem");
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
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
