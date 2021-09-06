using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models.ViewModel
{
    public class HomeVM
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int MenuId { get; set; }
        public ICollection<Menu> Menus { get; set; } = new HashSet<Menu>();
        public ICollection<MenuItem> MenuItems { get; set; } = new HashSet<MenuItem>();
        public ICollection<MenuMenuItem> MenuMenuItems { get; set; } = new HashSet<MenuMenuItem>();
        public ICollection<OrderItem> OrderItem { get; set; } = new HashSet<OrderItem>();
    }
}
