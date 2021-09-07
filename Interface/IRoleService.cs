using FOODEE.DTO;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IRoleService
    {
        public Role Add(RoleDto roleDto);

        public Role FindById(int id);

        public Role Update(RoleDto roleDto);

        public Role FindByName(string roleName);

        public IEnumerable<Role> GetAllRoles();

        public IEnumerable<Role> GetRolesWithoutAdmin();

        public void Delete(int id);
    }
}
