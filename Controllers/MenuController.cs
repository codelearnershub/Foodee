using FOODEE.Interface;
using FOODEE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _menuService.GetAll();
            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int? id)
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Menu menu)
        {
            if (ModelState.IsValid)
            {
                _menuService.Add(menu);
            }
            return RedirectToAction(("Index"));
            //return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
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

        [HttpPost]
        public IActionResult Edit(int id, Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _menuService.Update(menu);
                return View();
            }
            return View(menu);
        }

        [HttpPut]
        public IActionResult Update(int? id, Menu menu)
        {
            var category = _menuService.FindById(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _menuService.Update(menu);
            }
            return View(menu);
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
