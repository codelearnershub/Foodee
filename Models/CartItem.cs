namespace FOODEE.Models
{
    public class CartItem : BaseEntity
    {
        public  Cart Cart { get; set; }
        public  int CartId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int MenuItemId { get; set; }
    }
}