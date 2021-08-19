using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IOrderItemRepository
    {
        public OrderItem Add(OrderItem orderItem);
        public OrderItem Update(OrderItem orderItem);
        public void Delete(int id);
        public OrderItem FindById(int id);
        public List<OrderItem> GetAll();
        public bool Exists(int id);
    }
}
