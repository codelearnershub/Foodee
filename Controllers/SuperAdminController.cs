using FOODEE.Interface;
using FOODEE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Controllers
{
    public class SuperAdminController : Controller
    {
        private readonly IMenuService _menuService;

        public SuperAdminController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public IActionResult Index()
        {
            IEnumerable<Menu> menus = _menuService.GetAllMenus();

            return View(menus);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = _menuService.FindById(id.Value);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _menuService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
