using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models
{
    public class UserRole : BaseEntity
    {
        public Role Role { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
