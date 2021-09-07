using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IMenuItemRepository
    {
        public MenuItem Add(MenuItem menuitem);
        public MenuItem Update(MenuItem menuitem);
        public MenuItem FindById(int id);
        public void Delete(int id);
        public List<MenuItem> GetAll();
        public List<MenuItem> GetAll(IEnumerable<int> menuitemIds);
        public bool Exists(int id);
        public IList<MenuItem> Search(string searchText);

        public IList<MenuItem> GetMenuItemsByMenuId(int menuId);
    }
}
