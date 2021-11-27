using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop
{
    public class ShoppingCart
    {
        public List<ShoppingCartProduct> ShoppingCartProducts { get; }

        public User BoughtByUser { get; private set; }

        public ShoppingCart()
        {
            ShoppingCartProducts = new List<ShoppingCartProduct>();
        }

        public void AddProductToCart(Product product, int price, int quantity)
        {
            if (product == null) throw new Exception("Product should be not null.");
            if (product.Prices.All(p => p != price)) throw new Exception("Price is not defined for this product.");
            if (quantity < 1) throw new Exception("Quantity cannot be less than one.");

            ShoppingCartProducts.Add(new ShoppingCartProduct(product, price, quantity));
        }

        public bool RemoveProductFromCart(ShoppingCartProduct shoppingCartProduct)
        {
            return ShoppingCartProducts.Remove(shoppingCartProduct);
        }

        public void Purchase(User user)
        {
            foreach (var shoppingCardProduct in ShoppingCartProducts)
            {
                var product = shoppingCardProduct.Product;

                if (product.ProductType == ProductType.Normal)
                {
                    var stockQuantity = product.StockQuantity ?? 0;
                    if (shoppingCardProduct.Quantity > stockQuantity)
                    {
                        product.Seller.Inform(new NotEnoughQuantityEvent(product));
                        return;
                    }
                }

                product.Seller.Inform(new ProductSoldEvent(user, product));
            }

            BoughtByUser = user;
        }

        public int Total => ShoppingCartProducts.Select(x => x.TotalAmount).Sum();

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Join("\n", ShoppingCartProducts.Select(x => x.ToString())));
            result.AppendLine("Total Amount: " + Total);
            return result.ToString();
        }
    }
}