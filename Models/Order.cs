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
        public Customer Customer { get; set; }
        public int userId { get; set; }
        
        public Cart Cart { get; set; }
        public int CartId { get; set; }
        //public Payment Payment { get; set; }
        public int PaymentId { get; set; }
        public string DeliveryAddress { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateDelivered { get; set; }
    }
}
