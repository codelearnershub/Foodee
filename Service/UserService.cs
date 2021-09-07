using FOODEE.DTO;
using FOODEE.Interface;
using FOODEE.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace FOODEE.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }


        public void RegisterUser(CreateUserDto createuserDto)
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string saltString = Convert.ToBase64String(salt);

            string hashedPassword = HashPassword(createuserDto.Password, saltString);

            User user = new User
            {
                CreatedAt = DateTime.Now,
                LastName = createuserDto.LastName,
                FirstName = createuserDto.FirstName,
                Email = createuserDto.Email,
                PhoneNumber = createuserDto.PhoneNumber,
                Address = createuserDto.Address,
                Gender = createuserDto.Gender,
                HashSalt = saltString,
                PasswordHash = hashedPassword,
            };

            _userRepository.Add(user);

            int id = _userRepository.FindByEmail(createuserDto.Email).Id;

            UserRole userRole = new UserRole
            {
                CreatedAt = DateTime.Now,
                UserId = id,
                RoleId = createuserDto.RoleId,

            };
            _userRoleRepository.Add(userRole);
        }

        private string HashPassword(string password, string salt)
        {
            byte[] saltByte = Convert.FromBase64String(salt);
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltByte,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public User LoginUser(CreateUserDto createuserDto)
        {
            User user = _userRepository.FindByEmail(createuserDto.Email);

            if (user == null)
            {

                return null;
            }

            string hashedPassword = HashPassword(createuserDto.Password, user.HashSalt);

            if (user.PasswordHash.Equals(hashedPassword))
            {

                return user;
            }

            return null;
        }

        public User FindById(int Id)
        {
            return _userRepository.FindById(Id);
        }

        public User Update(CreateUserDto createuserDto)
        {
            User user = _userRepository.FindById(createuserDto.Id);

            if (user == null)
            {
                return null;
            }

            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string saltString = Convert.ToBase64String(salt);

            string hashedPassword = HashPassword(createuserDto.Password, saltString);

            user.LastName = createuserDto.LastName;
            user.FirstName = createuserDto.FirstName;
            user.Email = createuserDto.Email;
            user.PhoneNumber = createuserDto.PhoneNumber;
            user.Address = createuserDto.Address;
            user.Gender = createuserDto.Gender;
            user.HashSalt = saltString;
            user.PasswordHash = hashedPassword;



            var userRole = _userRoleRepository.FindUserRole(createuserDto.Id);
            if (userRole != null)
            {
                userRole.UserId = createuserDto.Id;
                userRole.RoleId = createuserDto.RoleId;

                _userRoleRepository.Update(userRole);
            }
            return _userRepository.Update(user);
        }

        public IEnumerable<User> GetAllUser(int userId)
        {
            return _userRepository.GetAllUser(userId);
        }

        public User FindByEmail(string userEmail)
        {
            return _userRepository.FindByEmail(userEmail);
        }

        public void Delete(int id)
        {
            var userRole = _userRoleRepository.FindUserRole(id);
            _userRepository.Delete(id);
            _userRoleRepository.Delete(userRole.Id);
        }
    }
}
