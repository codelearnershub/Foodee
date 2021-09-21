using System.Collections.Generic;

namespace FOODEE.DTO
{
    public class CartDto
    {
        public class ItemAdded
        {
            public int Id { get; set; }
            public int userId { get; set; }
            public bool IsCheckedOut { get; set; }
            
            public int NumberOfItem { get; set; }
            public List<CartItem> CartItems { get; set; }
        }

        public class CartItem
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string Image { get; set; }
        }
    }
}