using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Service
{
    public class MenuService
    {
        private readonly IMenuRepository menuRepository;

        public MenuService(IMenuRepository categoryRepository)
        {
            this.menuRepository = categoryRepository;
        }
        public Menu FindById(int id)
        {
            return menuRepository.FindById(id);
        }

        public Menu Add(Menu menu)
        {
            return menuRepository.Add(menu);
        }

        public Menu Update(Menu menu)
        {
            return menuRepository.Update(menu);
        }

        public void Delete(int id)
        {
            menuRepository.Delete(id);
        }

        public List<Menu> GetAll()
        {
            return menuRepository.GetAll();
        }

        public bool Exists(int id)
        {
            return menuRepository.Exists(id);
        }
    }
}
