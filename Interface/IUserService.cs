using FOODEE.DTO;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IUserService
    {
        public void RegisterUser(CreateUserDto createuserDto);

        public User LoginUser(CreateUserDto createuserDto);

        public User FindById(int Id);

        public User FindByEmail(string userEmail);
        public User Update(CreateUserDto createuserDto);

        public IEnumerable<User> GetAllUser(int userId);

        public void Delete(int id);
    }
}
