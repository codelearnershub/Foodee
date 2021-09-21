using System.Collections.Generic;
using FOODEE.Context;
using FOODEE.Interface;
using FOODEE.Models;

namespace FOODEE.Repository
{
    public class CartItemRepository: ICartItemRepository

    {
        
        private readonly FOODEEDbContext _dbContext;
        public CartItemRepository(FOODEEDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public CartItem Add(CartItem cartItem)
        {
            _dbContext.CartItems.Add(cartItem);
            _dbContext.SaveChanges();
            return cartItem;
        }

        public List<CartItem> AddMany(List<CartItem> cartItems)
        {
            _dbContext.CartItems.AddRange(cartItems);
            _dbContext.SaveChanges();
            return cartItems;
        }
    }
}