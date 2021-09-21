using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Service
{
    public class MenuMenuItemService: IMenuMenuItemService
    {
        private readonly IMenuMenuItemRepository menumenuitemRepository;

        public MenuMenuItemService(IMenuMenuItemRepository menumenuitemRepository)
        {
            this.menumenuitemRepository = menumenuitemRepository;
        }
        public MenuMenuItem FindById(int id)
        {
            return menumenuitemRepository.FindById(id);
        }

        public MenuMenuItem Add(MenuMenuItem menumenuItem)
        {
            return menumenuitemRepository.Add(menumenuItem);
        }

        public MenuMenuItem Update(MenuMenuItem menumenuItem)
        {
            return menumenuitemRepository.Update(menumenuItem);
        }
        public IEnumerable<MenuMenuItem> GetMenuByMenuItemId(int menuitemId)
        {
            return menumenuitemRepository.GetMenuByMenuItemId(menuitemId);
        }
        public IEnumerable<MenuMenuItem> GetByMenu(int menuId)
        {
            return menumenuitemRepository.GetByMenu(menuId);
        }
        public void Delete(int id)
        {
            menumenuitemRepository.Delete(id);
        }
    }
}
