using FOODEE.Context;
using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOODEE.Utility;
using Microsoft.EntityFrameworkCore;

namespace FOODEE.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly FOODEEDbContext _dbContext;

        public CartRepository(FOODEEDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Cart Add(Cart cart)
        {
            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();
            return cart;
        }

        public IEnumerable<Cart> GetCartsByUserId(int id)
        {
            return _dbContext.Carts.Where(c => c.userId == id).ToList();
        }

        public Cart Update(Cart cart)
        {
            _dbContext.Carts.Update(cart);
            _dbContext.SaveChanges();
            return cart;
        }

        public Cart FindById(int id)
        {
            return _dbContext.Carts.Find(id);
        }

        public void Delete(int id)
        {
            var cart = new Cart
            {
                Id = id
            };
            if (cart != null)
            {
                _dbContext.Carts.Remove(cart);
                _dbContext.SaveChanges();
            }
        }

        public List<Cart> GetAll()
        {
            return _dbContext.Carts.ToList();
        }

        public Cart GetActiveCart(int userId)
        {
            return _dbContext.Carts
                .Include(c => c.CartItems)
                .ThenInclude(c => c.MenuItem)
                .SingleOrDefault(c => c.userId == userId && c.IsCheckedOut == false);
        }

        public int GetNumberOfCartItems(int userId)
        {
            return _dbContext.Carts
                .Include(c => c.CartItems)
                .ThenInclude(c => c.MenuItem)
                .SingleOrDefault(c => c.userId == userId && c.IsCheckedOut == false)
                .CartItems.Distinct(new Comparers.CartItemComparer())
                .Count();
        }
    }
}