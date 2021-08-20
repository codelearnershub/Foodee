using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Service
{
    public class MenuItemService: IMenuItemService
    {
        private readonly IMenuItemRepository menuitemRepository;

        public MenuItemService(IMenuItemRepository menuitemRepository)
        {
            this.menuitemRepository = menuitemRepository;
        }

        public MenuItem FindById(int id)
        {
            return menuitemRepository.FindById(id);
        }

        public MenuItem Add(MenuItem menuitem)
        {
            return menuitemRepository.Add(menuitem);
        }

        public MenuItem Update(MenuItem menuitem)
        {
            return menuitemRepository.Update(menuitem);
        }

        public void Delete(int id)
        {
            menuitemRepository.Delete(id);
        }

        public List<MenuItem> GetAll()
        {
            return menuitemRepository.GetAll();

        }
        public bool Exists(int id)
        {
            return menuitemRepository.Exists(id);
        }

        public IList<MenuItem> Search(string searchText)
        {

            return menuitemRepository.Search(searchText);
        }
    }
}
