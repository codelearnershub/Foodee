using FOODEE.Models;

namespace FOODEE.Interface
{
    public interface ICustomerRepository
    {
        public Customer Add(Customer user);

        public Customer FindByUserId(int userId);
    }
}