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
       public string Description { get; set; }
       public decimal Quantity { get; set; }
        public virtual ICollection<MenuItem> MenuItem { get; set; } = new List<MenuItem>();

    }
}
