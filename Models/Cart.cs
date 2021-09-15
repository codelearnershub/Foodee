using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models
{
    public class Cart: BaseEntity
    {
        public int userId { get; set; }
        public User User { get; set; }
        public int MenuItemId { get; set; }

        public MenuItem MenuItem { get; set; } = new MenuItem();
    }
}
