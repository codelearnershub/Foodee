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
        public void Delete(int id);
        public Role FindById(int id);
        public Role Update(Role role);
        public Role FindByName(string name);
        public List<Role> GetAll();
    }
}
