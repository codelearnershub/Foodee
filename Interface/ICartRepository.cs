using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface ICartRepository
    {
        public IEnumerable<Cart> GetCartsByUserId(int id);
        public Cart Add(Cart cart);
        public Cart Update(Cart cart);
        public Cart FindById(int id);
        public void Delete(int id);
        public List<Cart> GetAll();
    }
}
