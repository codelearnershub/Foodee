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
    public class MenuItemRepository:IMenuItemRepository
    {
        private readonly FoodeeDbContext _dbContext;
        public MenuItemRepository(FoodeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MenuItem Add(MenuItem menuitem)
        {
            _dbContext.MenuItems.Add(menuitem);
            _dbContext.SaveChanges();
            return menuitem;
        }
        public MenuItem Update(MenuItem menuitem)
        {
            _dbContext.MenuItems.Update(menuitem);
            _dbContext.SaveChanges();
            return menuitem;
        }
        public MenuItem FindById(int id)
        {
            return _dbContext.MenuItems.Find(id);
        }
        public void Delete(int id)
        {
            var menuitem = new MenuItem
            {
                Id = id
            };
            if (menuitem != null)
            {
                _dbContext.MenuItems.Remove(menuitem);
                _dbContext.SaveChanges();
            }
        }

        public List<MenuItem> GetAll()
        {
            return _dbContext.MenuItems.Include(m => m.MenuMenuItems).ThenInclude(m => m.Menu).ToList();

        }

        public List<MenuItem> GetAll(IEnumerable<int> menuitemIds)
        {
            return _dbContext.MenuItems.Where(menuitem => menuitemIds.Contains(menuitem.Id)).ToList();

        }

        public bool Exists(int id)
        {
            return _dbContext.MenuItems.Any(e => e.Id == id);
        }

        public IList<MenuItem> Search(string searchText)
        {
            return _dbContext.MenuItems.Where(menuitem => EF.Functions.Like(menuitem.Name, $"%{searchText}%")).ToList();
        }

        public IList<MenuItem> GetMenuItemsByMenuId(int menuId)
        {
            return _dbContext.MenuItems
                .Include(m => m.MenuMenuItems)
                .Where(m => m.MenuMenuItems.All(m => m.MenuId == menuId)).ToList();
        }
    }
}
