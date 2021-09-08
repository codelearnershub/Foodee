using FOODEE.DTO;
using FOODEE.Interface;
using FOODEE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static FOODEE.Models.ViewModel.MenuVM;

namespace FOODEE.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IMenuMenuItemService _menumenuitemService;
        private readonly IMenuItemService _menuitemService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MenuController(IMenuService menuService,IMenuMenuItemService menumenuitemService, IMenuItemService menuitemService, IWebHostEnvironment webHostEnvironment)
        {
            _menuService = menuService;
            _menumenuitemService = menumenuitemService;
            _menuitemService = menuitemService;
            _webHostEnvironment = webHostEnvironment;

        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Menu> menus = _menuService.GetAllMenus();

            return View(menus);
        }
        [HttpGet]
        public IActionResult GetMenuItemByMenuId(int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var menumenuItem = _menumenuitemService.GetMenuItemByMenuId(id);
            List<MenuItem> MenuItems = new List<MenuItem>();
            foreach (var item in menumenuItem)
            {
                var menuitem = _menuitemService.FindById(item.MenuItemId);
                MenuItems.Add(menuitem);
            }

            return View(MenuItems);
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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreateMenuViewModel createmenuViewmodel)
        {
            var menuDto = new MenuDto();
            if (ModelState.IsValid)
            {
                if (createmenuViewmodel.Image.FileName != null)
                {
                    var file = createmenuViewmodel.Image;
                    string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Image");
                    Directory.CreateDirectory(imageDirectory);
                    string contentType = file.ContentType.Split('/')[1];
                    string fileName = $"{Guid.NewGuid()}.{contentType}";
                    string fullPath = Path.Combine(imageDirectory, fileName);
                    menuDto.Image = fileName;
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
            }
            menuDto.Name = createmenuViewmodel.Name;
            menuDto.Description = createmenuViewmodel.Description;
            menuDto.MenuItems = createmenuViewmodel.MenuItems;
            _menuService.Add(menuDto);
            return View(createmenuViewmodel);
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
            var menud = _menuService.FindById(id.Value);
            if (menud == null)
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
