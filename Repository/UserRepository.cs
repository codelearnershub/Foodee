using FOODEE.Context;
using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly FOODEEDbContext _dbContext;

        public UserRepository(FOODEEDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public void Delete(int userId)
        {
            var user = FindById(userId);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public User FindById(int userId)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id.Equals(userId));
        }
        public List<User> GetAllUser(int userId)
        {
            return _dbContext.Users.Where(u => u.Id != 1 && u.Id != userId).OrderByDescending(r => r.CreatedAt).ToList();
        }

        public User FindByEmail(string userEmail)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email.Equals(userEmail));
        }

        public User Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return user;
        }
    }
}
