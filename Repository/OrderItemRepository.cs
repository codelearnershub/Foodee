using FOODEE.Context;
using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Repository
{
    public class OrderItemRepository: IOrderItemRepository
    {
        private readonly FoodeeDbContext _dbContext;
        public OrderItemRepository(FoodeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public OrderItem Add(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            _dbContext.SaveChanges();
            return orderItem;
        }

        public OrderItem Update(OrderItem orderItem)
        {
            _dbContext.OrderItems.Update(orderItem);
            _dbContext.SaveChanges();
            return orderItem;
        }

        public void Delete(int id)
        {
            var orderItem = new OrderItem
            {
                Id = id
            };
            if (orderItem != null)
            {
                _dbContext.OrderItems.Remove(orderItem);
                _dbContext.SaveChanges();
            }
        }
        public OrderItem FindById(int id)
        {
            return _dbContext.OrderItems.Find(id);
        }

        public List<OrderItem> GetAll()
        {
            return _dbContext.OrderItems.ToList();

        }
        public bool Exists(int id)
        {
            return _dbContext.OrderItems.Any(e => e.Id == id);
        }
    }
}
