using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models
{
    public class OrderItem:BaseEntity
    {
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual Order Order { get; set; }
        public  MenuItem MenuItem { get; set; }
        public virtual MenuMenuItem MenuMenuItem { get; set; }

    }
}
