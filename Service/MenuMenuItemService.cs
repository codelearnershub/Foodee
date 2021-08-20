using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Service
{
    public class MenuMenuItemService: IMenuMenuItemService
    {
        private readonly IMenuMenuItemRepository menumenuItemRepository;

        public MenuMenuItemService(IMenuMenuItemRepository menumenuItemRepository)
        {
            this.menumenuItemRepository = menumenuItemRepository;
        }
        public MenuMenuItem FindById(int id)
        {
            return menumenuItemRepository.FindById(id);
        }

        public MenuMenuItem Add(MenuMenuItem menumenuItem)
        {
            return menumenuItemRepository.Add(menumenuItem);
        }

        public MenuMenuItem Update(MenuMenuItem menumenuItem)
        {
            return menumenuItemRepository.Update(menumenuItem);
        }

        public void Delete(int id)
        {
            menumenuItemRepository.Delete(id);
        }
    }
}
