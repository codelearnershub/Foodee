using FOODEE.DTO;
using FOODEE.Interface;
using FOODEE.Models;
using FOODEE.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FOODEE.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IMenuItemService _menuitemService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMenuService _menuService;
        private readonly ICartService _cartService;

        public MenuItemController(IMenuItemService menuitemService, IWebHostEnvironment webHostEnvironmrnt, IMenuService menuService, ICartService cartService)
        {
            _menuitemService = menuitemService;
            _webHostEnvironment = webHostEnvironmrnt;
            _menuService = menuService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View(_menuitemService.GetAll());
        }
        [Authorize]
        public IActionResult IndexAdmin()
        {
            IEnumerable<MenuItem> menuitems = _menuitemService.GetAll();

            return View(menuitems);
        }

        public IActionResult IndexAnonymous()
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
        public IActionResult Add(MenuItemVM menuitemVm)
        {
            var menuItemDto = new MenuItemDto();
            if (ModelState.IsValid)
            {
                if (menuitemVm.Image.FileName != null)
                {
                    var file = menuitemVm.Image;
                    string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Image");
                    Directory.CreateDirectory(imageDirectory);
                    string contentType = file.ContentType.Split('/')[1];
                    string fileName = $"{Guid.NewGuid()}.{contentType}";
                    string fullPath = Path.Combine(imageDirectory, fileName);
                    menuItemDto.Image = fileName;
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
            }
            menuItemDto.Name = menuitemVm.Name;
            menuItemDto.Price = menuitemVm.Price;
            menuItemDto.Description = menuitemVm.Description;
            menuItemDto.Menus = menuitemVm.Menus; 
            _menuitemService.Add(menuItemDto);
            return View(menuitemVm);
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
            ViewBag.Menus = listAMenuItems;
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
            return RedirectToAction(nameof(Index));
        }
    }
}
