using FOODEE.Context;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Repository
{
    public class UserRepository
    {
        private readonly FoodeeDbContext _dbContext;
        public UserRepository(FoodeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }
        public User FindById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public void Delete(int id)
        {
            var user = FindById(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }
        public User Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return user;
        }
        public User FindByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(c => c.Email == email);
        }
        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();

        }
        public bool Exists(int id)
        {
            return _dbContext.Users.Any(e => e.Id == id);
        }
    }
}
