using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Service
{
    public class UserRoleService: IUserRoleService
    {
        private readonly IUserRoleRepository userroleRepository;

        public UserRoleService(IUserRoleRepository userroleRepository)
        {
            this.userroleRepository = userroleRepository;
        }
        public UserRole FindById(int id)
        {
            return userroleRepository.FindById(id);
        }

        public UserRole Add(UserRole userrole)
        {
            return userroleRepository.Add(userrole);
        }

        public UserRole Update(UserRole userrole)
        {
            return userroleRepository.Update(userrole);
        }

        public void Delete(int id)
        {
            userroleRepository.Delete(id);
        }

        public List<UserRole> GetAll()
        {
            return userroleRepository.GetAll();

        }
        public bool Exists(int id)
        {
            return userroleRepository.Exists(id);
        }
    }
}
