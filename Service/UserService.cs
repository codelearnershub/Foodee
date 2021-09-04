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
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public User LoginUser(string email, string password)
        {
            User user = userRepository.FindByEmail(email);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return null;
            }

            string hashedPassword = HashPassword(password, user.HashSalt);

            if (user.PasswordHash.Equals(hashedPassword))
            {
                Console.WriteLine("User is found");
                return user;
            }

            return null;
        }
        public void RegisterUser(CreateUserDto createUserDto)
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string saltString = Convert.ToBase64String(salt);

            string hashedPassword = HashPassword(createUserDto.Password , saltString);

            var role = _roleRepository.FindByName("Customer").Id;

            var userRoles = new List<UserRole>();
            {
                new UserRole
                {
                    RoleId = role,
                    UserId = createUserDto.Id
                };
            };

            User user = new User
            {
                Id = createUserDto.Id,
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Address = createUserDto.Address,
                PhoneNumber = createUserDto.PhoneNumber,
                Email = createUserDto.Email,
                Gender = createUserDto.Gender,
                HashSalt = saltString,
                PasswordHash = hashedPassword,
            };

            userRepository.Add(user);
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
            Console.WriteLine($"Hashed: {hashed}");

            return hashed;
        }
    }
}
