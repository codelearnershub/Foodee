using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodee.DTO
{
    public class LSCartDto
    {

        public int itemId { get; set; }
        public string name { get; set; }

        public int price { get; set; }

        public int quatity { get; set; }
    }
}
