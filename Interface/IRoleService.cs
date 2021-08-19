using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IRoleService
    {
        public Role Add(Role role);
        public Role Update(Role role);
        public void Delete(int id);
        public List<Role> GetAll();
        public bool Exists(int id);
        public Role FindById(int id);
    }
}
