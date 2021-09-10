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
    public class MenuMenuItemRepository: IMenuMenuItemRepository
    {
        private readonly FoodeeDbContext _dbContext;
        public MenuMenuItemRepository(FoodeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MenuMenuItem Add(MenuMenuItem menumenuitem)
        {
            _dbContext.MenuMenuItems.Add(menumenuitem);
            _dbContext.SaveChanges();
            return menumenuitem;
        }
        public MenuMenuItem Update(MenuMenuItem menumenuitem)
        {
            _dbContext.MenuMenuItems.Update(menumenuitem);
            _dbContext.SaveChanges();
            return menumenuitem;
        }
        public List<MenuMenuItem> GetByMenu(int menuId)
        {
            return _dbContext.MenuMenuItems.Include(c => c.MenuItem).Where(c => c.MenuId == menuId).ToList();
        }
        public List<MenuMenuItem> GetMenuByMenuItemId(int menuitemId)
        {
            return _dbContext.MenuMenuItems.Include(p => p.Menu).Where(p => p.MenuItemId == menuitemId).ToList();
        }
        public MenuMenuItem FindById(int id)
        {
            return _dbContext.MenuMenuItems.Find(id);
        }
        public void Delete(int id)
        {
            var menumenuitem = new MenuMenuItem
            {
                Id = id
            };
            if (menumenuitem != null)
            {
                _dbContext.MenuMenuItems.Remove(menumenuitem);
                _dbContext.SaveChanges();
            }
        }
    }
}
