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
        public User LoginUser(string email, string password);

        public void RegisterUser(CreateUserDto createUserDto);
    }
}
