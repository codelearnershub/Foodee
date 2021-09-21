using FOODEE.Models;

namespace FOODEE.Interface
{
    public interface ICustomerService
    {
        public Customer AddCustomer(Customer customer);

        public Customer GetByUserId(int userId);
    }
}