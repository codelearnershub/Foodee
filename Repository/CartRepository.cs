using FOODEE.Context;
using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Repository
{
    public class CartRepository: ICartRepository
    {
        private readonly FoodeeDbContext _dbContext;
        public CartRepository(FoodeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Cart Add(Cart cart)
        {
            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();
            return cart;
        }
        public IEnumerable<Cart>  GetCartsByUserId(int id)
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
    }
}
