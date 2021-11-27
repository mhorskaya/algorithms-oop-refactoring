using System.Collections.Generic;

namespace Shop
{
    public class Shop
    {
        public List<ShoppingCart> ShoppingCarts { get; }

        public Shop()
        {
            ShoppingCarts = new List<ShoppingCart>();
        }
    }
}