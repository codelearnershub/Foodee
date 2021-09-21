using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IUserRoleRepository
    {
        public UserRole Add(UserRole userRole);

        public UserRole FindById(int userRoleId);

        public string FindRole(int userId);

        public UserRole FindUserRole(int userId);

        public List<UserRole> FindUsersWithParticularRole(int roleId);

        public UserRole FindUserWithParticularRole(int roleId);

        public UserRole Update(UserRole userRole);

        public void Delete(int userRoleId);
    }
}
