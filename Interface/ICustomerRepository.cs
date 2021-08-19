using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface ICustomerRepository
    {
        public Customer Add(Customer customer);
        public Customer FindById(int id);
        public void Delete(int id);
        public Customer Update(Customer customer);
        public Customer FindByEmail(string email);
        public List<Customer> GetAll();
        public bool Exists(int id);
    }
}
