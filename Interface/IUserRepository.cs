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

        public User FindById(int userId);

        public User FindByEmail(string userEmail);

        public List<User> GetAllUser(int userId);

        public User Update(User user);

        public void Delete(int userId);
    }
}
