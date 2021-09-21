using System.Collections.Generic;

namespace FOODEE.Models
{
    public class Customer
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Order> Orders { get; set; } = new List<Order>();
        //public List<Payment> Payments { get; set; } = new List<Payment>();
    }
}