using FOODEE.DTO;
using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Service
{
    public class MenuService: IMenuService
    {
        private readonly IMenuRepository menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }
        public Menu FindById(int id)
        {
            return menuRepository.FindById(id);
        }

        public Menu Add(MenuDto menuDto)
        {

            var menu = new Menu
            {
                Image = menuDto.Image,
                Quantity = menuDto.Quantity,
                Description = menuDto.Description,
                Name = menuDto.Name,
            };
            var menuMenuItems = new List<MenuMenuItem>();
            foreach (var id in menuDto.MenuItems)
            {
                var menuMenuItem = new MenuMenuItem
                {
                    MenuItemId = int.Parse(id),
                    MenuId = menu.Id,
                };
                menuMenuItems.Add(menuMenuItem);
            }
            menu.MenuMenuItems = menuMenuItems;
            return menuRepository.Add(menu);
        }

        public Menu Update(Menu menu)
        {
            return menuRepository.Update(menu);
        }

        public void Delete(int id)
        {
            menuRepository.Delete(id);
        }

        public IEnumerable<Menu> GetAllMenus()
        {
            var menus = menuRepository.GetAllMenus().Select(c => new Menu
            {
                Id = c.Id,
                CreatedAt = DateTime.Now,
                Name = c.Name,
                Image = c.Image,
            }).ToList();

            return menus;
        }
        public List<Menu> GetAll()
        {
            return menuRepository.GetAll();
        }

        public bool Exists(int id)
        {
            return menuRepository.Exists(id);
        }
    }
}
