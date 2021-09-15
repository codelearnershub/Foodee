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
        public Cart Add(Cart cart);
        public Cart Update(Cart cart);
        public void Delete(int id);
        public List<Cart> GetAll();
        public IEnumerable<Cart> GetCartsByUserId(int id);
    }
}
