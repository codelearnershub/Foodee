using System.Collections.Generic;
using FOODEE.Models;

namespace FOODEE.Interface
{
    public interface ICartItemRepository
    {
        public CartItem Add(CartItem cartItem);

        public List<CartItem> AddMany(List<CartItem> cartItems);
    }
}