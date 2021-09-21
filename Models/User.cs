using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models
{
    public class User:Details
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string HashSalt { get; set; }
        public List<UserRole> UserRoles { get; set; }

        public Customer Customer { get; set; }
        public Admin Admin { get; set; }
        public SuperAdmin SuperAdmin { get; set; }
    }
}
