using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface ICustomerService
    {
        public Customer FindById(int id);

        public Customer Add(Customer customer);

        public Customer Update(Customer customer);

        public void Delete(int id);

        public List<Customer> GetAll();

        public bool Exists(int id);
    }
}
