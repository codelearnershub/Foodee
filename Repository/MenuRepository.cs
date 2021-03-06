using FOODEE.Context;
using FOODEE.Interface;
using FOODEE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Repository
{
    public class MenuRepository: IMenuRepository
    {
        private readonly FoodeeDbContext _dbContext;
        public MenuRepository(FoodeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Menu Add(Menu menu)
        {
            _dbContext.Menus.Add(menu);
            _dbContext.SaveChanges();
            return menu;
        }
        public Menu FindById(int id)
        {
            return _dbContext.Menus.Find(id);
        }

        public void Delete(int id)
        {
            var menu = FindById(id);
            if (menu != null)
            {
                _dbContext.Menus.Remove(menu);
                _dbContext.SaveChanges();
            }
        }
        public Menu Update(Menu menu)
        {
            _dbContext.Menus.Update(menu);
            _dbContext.SaveChanges();
            return menu;
        }
        public List<Menu> GetAll()
        {
            return _dbContext.Menus
                .Include(m => m.MenuItems)
                .ToList();

        }
        public bool Exists(int id)
        {
            return _dbContext.Menus.Any(e => e.Id == id);
        }
    }
}
