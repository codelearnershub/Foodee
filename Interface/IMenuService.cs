using FOODEE.DTO;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IMenuService
    {
        public Menu Update(Menu menu);

        public void Delete(int id);

        public IEnumerable<Menu> GetAllMenus();
        public List<Menu> GetAll();
        public Menu Add(MenuDto menuDto);
        public bool Exists(int id);
        public Menu FindById(int id);
    }
}
