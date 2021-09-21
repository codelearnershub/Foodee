using FOODEE.Context;
using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly FOODEEDbContext _dbContext;
        public OrderRepository(FOODEEDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Order Add(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return order;
        }

        public Order Update(Order order)
        {
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
            return order;
        }

        public void Delete(int id)
        {
            var order = new Order
            {
                Id = id
            };
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }
        }
        public Order FindById(int id)
        {
            return _dbContext.Orders.Find(id);
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders.ToList();

        }

        public bool Exists(int id)
        {
            return _dbContext.Orders.Any(e => e.Id == id);
        }
    }
}
