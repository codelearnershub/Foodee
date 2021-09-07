using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IRoleRepository
    {
        public Role Add(Role role);

        public Role FindById(int roleId);

        public Role Update(Role role);

        public Role FindByName(string roleName);

        public List<Role> GetAllRoles();

        public List<Role> GetRolesWithoutAdmin();

        public void Delete(int roleId);
    }
}
