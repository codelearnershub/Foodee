using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Service
{
    public class CartService
    {
        private readonly ICartRepository cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public Cart FindById(int id)
        {
            return cartRepository.FindById(id);
        }

        public Cart Add(Cart cart)
        {
            return cartRepository.Add(cart);
        }

        public Cart Update(Cart cart)
        {
            return cartRepository.Update(cart);
        }

        public void Delete(int id)
        {
            cartRepository.Delete(id);
        }

        public List<Cart> GetAll()
        {
            return cartRepository.GetAll();

        }
        public IEnumerable<Cart> GetCartsByUserId(int id)
        {
            return cartRepository.GetCartsByUserId(id);
        }
    }
}
