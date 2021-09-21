using FOODEE.Enum;
using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Service
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository orderRepository;

        private readonly IMenuItemRepository menuitemRepository;
        public OrderService(IOrderRepository orderRepository, IMenuItemRepository menuitemRepository)
        {
            this.orderRepository = orderRepository;
            this.menuitemRepository = menuitemRepository;
        }
        public Order FindById(int id)
        {
            return orderRepository.FindById(id);
        }
        public Order Add(Order order)
        {

            return orderRepository.Add(order);
        }
        public Order Update(Order order)
        {
            return orderRepository.Update(order);
        }

        public void Delete(int id)
        {
            orderRepository.Delete(id);
        }
        public List<Order> GetAll()
        {
            return orderRepository.GetAll();

        }
        public bool Exists(int id)
        {
            return orderRepository.Exists(id);
        }
    }
}
