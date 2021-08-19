using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IUserService
    {
        public User FindById(int id);

        public User Add(User customer);

        public User Update(User user);

        public void Delete(int id);

        public List<User> GetAll();

        public bool Exists(int id);
    }
}
