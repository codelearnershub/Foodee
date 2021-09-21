using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IOrderService
    {
        public Order Add(Order order);
        public Order Update(Order order);
        public void Delete(int id);
        public List<Order> GetAll();
        public Order FindById(int id);
        public bool Exists(int id);
    }
}
