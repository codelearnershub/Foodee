using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IUserRoleService
    {
        public UserRole Add(UserRole userrole);
        public UserRole Update(UserRole userrole);
        public void Delete(int id);
        public List<UserRole> GetAll();
        public  List<UserRole> FindUserRoles(int userId);
        public bool Exists(int id);
        public UserRole FindById(int id);
    }
}
