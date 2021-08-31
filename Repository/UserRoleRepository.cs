using FOODEE.Context;
using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Repository
{
    public class UserRoleRepository: IUserRoleRepository
    {
        private readonly FoodeeDbContext _dbContext;
        public UserRoleRepository(FoodeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public UserRole Add(UserRole userrole)
        {
            _dbContext.UserRoles.Add(userrole);
            _dbContext.SaveChanges();
            return userrole;
        }
        public UserRole FindById(int id)
        {
            return _dbContext.UserRoles.Find(id);
        }
        public List<UserRole> FindUserRoles(int userId)
        {
            return _dbContext.UserRoles.Where(ur => ur.userId == userId).ToList();
        }
        public void Delete(int id)
        {
            var userrole = FindById(id);
            if (userrole != null)
            {
                _dbContext.UserRoles.Remove(userrole);
                _dbContext.SaveChanges();
            }
        }
        public UserRole Update(UserRole userrole)
        {
            _dbContext.UserRoles.Update(userrole);
            _dbContext.SaveChanges();
            return userrole;
        }
        public List<UserRole> GetAll()
        {
            return _dbContext.UserRoles.ToList();

        }
        public bool Exists(int id)
        {
            return _dbContext.UserRoles.Any(e => e.Id == id);
        }
    }
}
