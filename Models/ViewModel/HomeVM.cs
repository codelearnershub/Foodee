using System.Collections.Generic;

namespace FOODEE.Models.ViewModel
{
    public class HomeVM
    {
        public class IndexAnonymous
        {
            public IEnumerable<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
            public int NumberOfCartItems { get; set; }
        }
    }
}