﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models
{
    public class MenuItem: BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public ICollection<MenuMenuItem> MenuMenuItems { get; set; } = new HashSet<MenuMenuItem>();
    }
}
