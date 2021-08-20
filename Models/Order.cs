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
        public int CustomerId { get; set; }
        public bool IsPaid { get; set; } 
        public Customer Customer { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
