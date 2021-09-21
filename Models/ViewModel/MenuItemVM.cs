using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models.ViewModel
{
    public class MenuItemVM: BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public string[] Menus { get; set; }
        public ICollection<Menu> Menuss { get; set; } = new HashSet<Menu>();
        public ICollection<MenuItem> MenuItems { get; set; } = new HashSet<MenuItem>();
        public ICollection<MenuMenuItem> MenuMenuItems { get; set; } = new HashSet<MenuMenuItem>();
    }
}
