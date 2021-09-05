using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IUserRoleRepository
    {
        public UserRole Add(UserRole userrole);
        public UserRole FindById(int id);
        public List<UserRole> FindUserRoles(int userId);
        public void Delete(int id);
        public UserRole Update(UserRole userrole);
        public List<UserRole> GetAll();
        public bool Exists(int id);
    }
}
