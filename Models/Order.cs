using FOODEE.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models
{
    public class Order:BaseEntity
    {
        public int userId { get; set; }
        public bool IsPaid { get; set; } 
        public string DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
