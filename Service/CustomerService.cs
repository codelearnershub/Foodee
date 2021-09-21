using FOODEE.Interface;
using FOODEE.Models;

namespace FOODEE.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer AddCustomer(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public Customer GetByUserId(int userId)
        {
            return _customerRepository.FindByUserId(userId);
        }
    }
}