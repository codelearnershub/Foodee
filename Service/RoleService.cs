using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Service
{
    public class RoleService: IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        public Role FindById(int id)
        {
            return roleRepository.FindById(id);
        }

        public Role FindByName(string name) 
        {
            return roleRepository.FindByName(name);
        }

        public Role Add(Role role)
        {
            return roleRepository.Add(role);
        }

        public Role Update(Role role)
        {
            return roleRepository.Update(role);
        }

        public void Delete(int id)
        {
            roleRepository.Delete(id);
        }

        public List<Role> GetAll()
        {
            return roleRepository.GetAll();

        }
    }
}
