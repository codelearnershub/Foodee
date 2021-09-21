using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface ICartService
    {
        public Cart FindById(int id);

        public Cart AddItemToCart(int menuItemId, int userId, int count =1);
        
        public Cart RemoveItemFromCart(int menuItemId, int userId);

        public Cart GetActiveCart(int userId);

        public Cart EmptyCart(int userId);

        public int GetNumberOfCartItems(int userId);
        
        public Cart Add(Cart cart);
        public Cart Update(Cart cart);
        public void Delete(int id);
        public List<Cart> GetAll();
        public IEnumerable<Cart> GetCartsByUserId(int id);
    }
}
