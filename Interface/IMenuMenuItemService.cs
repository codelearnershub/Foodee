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
        public List<MenuMenuItem> GetAll();
        public bool Exists(int id);
        public MenuMenuItem FindById(int id);
    }
}
