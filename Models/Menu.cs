using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models
{
    public class Menu: BaseEntity
    {
       public string Name { get; set; }
       public int MenuItemId { get; set; }
       public string Description { get; set; }
       public int Quantity { get; set; }
       public ICollection<MenuMenuItem> MenuItems { get; set; } = new HashSet<MenuMenuItem>();

    }
}
