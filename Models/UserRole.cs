using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models
{
    public class UserRole : BaseEntity
    {
        public int userId { get; set; }
        public int RoleId { get; set; }
    }
}
