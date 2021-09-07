using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models
{
    public class MenuMenuItem: BaseEntity
    {
        public int MenuId { get; set; }

        public int MenuItemId { get; set; }

        public Menu Menu { get; set; }

        public MenuItem MenuItem { get; set; }
    }
}
