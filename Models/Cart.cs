using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models
{
    public class Cart: BaseEntity
    {
        public int userId { get; set; }
        public Customer Customer { get; set; }
        public bool IsCheckedOut { get; set; }

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
