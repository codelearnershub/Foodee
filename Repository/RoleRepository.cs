using FOODEE.Context;
using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Repository
{
    public class RoleRepository: IRoleRepository
    {
        private readonly FoodeeDbContext _dbContext;
        public RoleRepository(FoodeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Role Add(Role role)
        {
            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();
            return role;
        }
        public void Delete(int id)
        {
            var role = FindById(id);
            if (role != null)
            {
                _dbContext.Roles.Remove(role);
                _dbContext.SaveChanges();
            }
        }
        public Role FindById(int id)
        {
            return _dbContext.Roles.Find(id);
        }
        public Role Update(Role role)
        {
            _dbContext.Roles.Update(role);
            _dbContext.SaveChanges();
            return role;
        }
        public List<Role> GetAll()
        {
            return _dbContext.Roles.ToList();

        }
    }
}
