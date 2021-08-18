using FOODEE.Context;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Repository
{
    public class CustomerRepository
    {
        private readonly FoodeeDbContext _dbContext;
        public CustomerRepository(FoodeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Customer Add(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }
        public Customer FindById(int id)
        {
            return _dbContext.Customers.Find(id);
        }

        public void Delete(int id)
        {
            var customer = FindById(id);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
            }
        }
        public Customer Update(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();
            return customer;
        }
        public Customer FindByEmail(string email)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.Email == email);
        }
        public List<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();

        }
        public bool Exists(int id)
        {
            return _dbContext.Customers.Any(e => e.Id == id);
        }
    }
}
