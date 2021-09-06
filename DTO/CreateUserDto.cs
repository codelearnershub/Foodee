using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.DTO
{
    public class CreateUserDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; } 
        public string Email { get; set; } 
        public string Gender { get; set; } 
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
