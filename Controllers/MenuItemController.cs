using FOODEE.Interface;
using FOODEE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IMenuItemService _menuitemService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMenuService _menuService;

        public MenuItemController(IMenuItemService menuitemService, IWebHostEnvironment webHostEnvironmrnt, IMenuService menuService)
        {
            _menuitemService = menuitemService;
            _webHostEnvironment = webHostEnvironmrnt;
            _menuService = menuService;
        }

        public IActionResult Index()
        {
            return View(_menuitemService.GetAll());
        }

        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = _menuitemService.FindById(id.Value);
            if (menuitem == null)
            {
                return NotFound();
            }
            return View(menuitem);

        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Menu> menus = _menuService.GetAll();
            List<SelectListItem> listAMenuItems = new List<SelectListItem>();
            foreach (Menu menu in menus)
            {
                SelectListItem menuitem = new SelectListItem(menu.Name, menu.Id.ToString());
                listAMenuItems.Add(menuitem);
            }

            ViewBag.Menus = listAMenuItems;
            return View( );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MenuItem menuitem, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    Directory.CreateDirectory(imageDirectory);
                    string contentType = file.ContentType.Split('/')[1];
                    string fileName = $"{Guid.NewGuid()}.{contentType}";
                    string fullPath = Path.Combine(imageDirectory, fileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    menuitem.Image = fileName;
                }
                _menuitemService.Add(menuitem);
                return RedirectToAction(nameof(Index));
            }
            return View(menuitem);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = _menuitemService.FindById(id.Value);
            if (menuitem == null)
            {
                return NotFound();
            }
            List<Menu> menus = _menuService.GetAll();
            List<SelectListItem> listAMenuItems = new List<SelectListItem>();
            foreach (Menu menu in menus)
            {
                SelectListItem menuitemList = new SelectListItem(menu.Name, menu.Id.ToString());
                listAMenuItems.Add(menuitemList);
            }
            ViewBag.Categories = listAMenuItems;
            return View(menuitem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MenuItem menuitem, IFormFile file)
        {
            if (id != menuitem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _menuitemService.Update(menuitem);
                return Ok();
            }
            return View(menuitem);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = _menuitemService.FindById(id.Value);
            if (menuitem == null)
            {
                return NotFound();
            }

            return View(menuitem);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _menuitemService.Delete(id);
            return View(new
            {
                redirectUri = Url.Action(nameof(Index))
            });
        }
    }
}
