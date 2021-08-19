using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IUserRepository
    {
        public User Add(User user);
        public User FindById(int id);
        public void Delete(int id);
        public User Update(User user);
        public User FindByEmail(string email);
        public List<User> GetAll();
        public bool Exists(int id);
    }
}
