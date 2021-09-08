using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IMenuMenuItemService
    {
        public MenuMenuItem Add(MenuMenuItem menumeniitem);
        public MenuMenuItem Update(MenuMenuItem menumenuitem);
        public void Delete(int id);
        public MenuMenuItem FindById(int id);
        public IEnumerable<MenuMenuItem> GetMenuByMenuItemId(int menuitemId);
        public IEnumerable<MenuMenuItem> GetMenuItemByMenuId(int menuId);
    }
}
