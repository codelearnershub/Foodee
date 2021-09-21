using FOODEE.Enum;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.DTO
{
    public class OrderDto
    {
        public int userId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public User User { get; set; }
    }
}
