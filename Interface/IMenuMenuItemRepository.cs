using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IMenuMenuItemRepository
    {
        public MenuMenuItem Add(MenuMenuItem menumenuitem);
        public MenuMenuItem Update(MenuMenuItem menumenuitem);
        public MenuMenuItem FindById(int id);
        public void Delete(int id);
        public List<MenuMenuItem> GetByMenu(int menuId);
        public List<MenuMenuItem> GetMenuByMenuItemId(int menuitemId);
    }
}
