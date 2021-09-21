using System.Collections.Generic;
using FOODEE.Models;

namespace FOODEE.Utility
{
    public class Comparers
    {
        public class CartItemComparer : IEqualityComparer<CartItem>
        {
            public bool Equals(CartItem x, CartItem y)
            {
                //First check if both object reference are equal then return true
                if(object.ReferenceEquals(x, y))
                {
                    return true;
                }
                //If either one of the object refernce is null, return false
                if (object.ReferenceEquals(x,null) || object.ReferenceEquals(y, null))
                {
                    return false;
                }
                //Comparing all the properties one by one
                return x.MenuItem.Id == y.MenuItem.Id && x.MenuItem.Name == y.MenuItem.Name;
            }
            public int GetHashCode(CartItem obj)
            {
                //If obj is null then return 0
                if (obj == null)
                {
                    return 0;
                }
                //Get the ID hash code value
                int IDHashCode = obj.MenuItem.Id.GetHashCode();
                //Get the string HashCode Value
                //Check for null refernece exception
                int NameHashCode = obj.MenuItem.Name == null ? 0 : obj.MenuItem.Name.GetHashCode();
                return IDHashCode ^ NameHashCode;
            }
        }
    }
}