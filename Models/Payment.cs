using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models
{
    public class Payment: BaseEntity
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
