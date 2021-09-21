using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IOrderRepository
    {
        public Order Add(Order order);
        public Order Update(Order order);
        public void Delete(int id);
        public Order FindById(int id);
        public List<Order> GetAll();
        public bool Exists(int id);
    }
}
