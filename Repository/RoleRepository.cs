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

        public void Delete(int roleId)
        {
            var role = FindById(roleId);

            if (role != null)
            {
                _dbContext.Roles.Remove(role);
                _dbContext.SaveChanges();
            }
        }

        public Role FindById(int roleId)
        {
            return _dbContext.Roles.FirstOrDefault(u => u.Id.Equals(roleId));
        }
        public Role FindByName(string roleName)
        {
            return _dbContext.Roles.FirstOrDefault(u => u.Name.Equals(roleName));
        }
        public List<Role> GetAllRoles()
        {

            return _dbContext.Roles.Where(r => r.Name != "Super Admin").OrderByDescending(r => r.CreatedAt).ToList();
        }
        public List<Role> GetRolesWithoutAdmin()
        {

            return _dbContext.Roles.Where(r => r.Name != "Admin" && r.Name != "Super Admin").OrderByDescending(r => r.CreatedAt).ToList();
        }
        public Role Update(Role role)
        {
            _dbContext.Roles.Update(role);
            _dbContext.SaveChanges();
            return role;
        }
    }
}
