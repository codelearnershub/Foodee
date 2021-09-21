using System.Linq;
using FOODEE.Context;
using FOODEE.Interface;
using FOODEE.Models;
using Microsoft.EntityFrameworkCore;

namespace FOODEE.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        
        private readonly FOODEEDbContext _dbContext;
        public CustomerRepository(FOODEEDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Customer Add(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public Customer FindByUserId(int userId)
        {
            return _dbContext.Customers
                .Include(c => c.User)
                .SingleOrDefault(c => c.UserId==userId);
        }
    }
}