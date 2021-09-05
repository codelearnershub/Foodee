using FOODEE.DTO;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IMenuItemService
    {
        public MenuItem Add(MenuItemDto menuitemDto);
        public MenuItem Update(MenuItem menuitem);
        public void Delete(int id);
        public List<MenuItem> GetAll();
        public bool Exists(int id);
        public MenuItem FindById(int id);
        public IList<MenuItem> Search(string searchText);
    }
}
