using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Service
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer Add(Customer customer)
        {
            return customerRepository.Add(customer);
        }
        public void Delete(int id)
        {
            customerRepository.Delete(id);
        }
        public Customer FindById(int id)
        {
            return customerRepository.FindById(id);
        }

        public Customer Update(Customer customer)
        {
            return customerRepository.Update(customer);
        }

        public List<Customer> GetAll()
        {
            return customerRepository.GetAll();

        }

        public bool Exists(int id)
        {
            return customerRepository.Exists(id);
        }
    }
}
