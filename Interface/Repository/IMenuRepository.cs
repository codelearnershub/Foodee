using FOODEE.DTO;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IMenuRepository
    {
        public Menu Add(Menu menu);
        public Menu FindById(int id);
        public void Delete(int id);
        public Menu Update(Menu menu);
        public List<Menu> GetAll();
        public IEnumerable<Menu> GetAllMenus();
        public bool Exists(int id);

    }
}
