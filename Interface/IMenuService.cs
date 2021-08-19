using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IMenuService
    {
        public Menu Add(Menu menu);

        public Menu Update(Menu menu);

        public void Delete(int id);

        public List<Menu> GetAll();

        public bool Exists(int id);
        public Menu FindById(int id);
    }
}
