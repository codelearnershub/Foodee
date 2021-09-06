using FOODEE.DTO;
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
        private readonly IRoleRepository _roleRepository;
        private readonly IUserService _userService;

        public RoleService(IRoleRepository roleRepository, IUserService userService)
        {
            _roleRepository = roleRepository;
            _userService = userService;
        }

        public Role Add(RoleDto roleDto)
        {
            var role = new Role
            {
                CreatedAt = DateTime.Now,
                Name = roleDto.Name,
            };

            return _roleRepository.Add(role);
        }

        public Role FindById(int id)
        {
            return _roleRepository.FindById(id);
        }

        public Role Update(RoleDto roleDto)
        {
            var role = _roleRepository.FindById(roleDto.Id);
            if (role == null)
            {
                return null;
            }

            role.Name = roleDto.Name;

            return _roleRepository.Update(role);
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }

        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }

        public Role FindByName(string roleName)
        {
            return _roleRepository.FindByName(roleName);
        }

        public IEnumerable<Role> GetRolesWithoutAdmin()
        {
            return _roleRepository.GetRolesWithoutAdmin();
        }
    }
}
