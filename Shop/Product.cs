using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop
{
    public class Product
    {
        public string Name { get; }

        public int ArticleNumber { get; }

        public List<int> Prices { get; }

        public List<string> Pictures { get; }

        public ProductType ProductType { get; }

        public User Seller { get; }

        public int? StockQuantity { get; }

        public ShipmentMethod ShipmentMethod { get; }

        public Product(string name, int articleNumber, int price, ProductType productType, User seller, int? stockQuantity, ShipmentMethod shipmentMethod = ShipmentMethod.Post)
        {
            Name = name;
            ArticleNumber = articleNumber;
            Prices = new List<int>(); AddPrice(price);
            Pictures = new List<string>();
            ProductType = productType;
            Seller = seller;

            switch (productType)
            {
                case ProductType.Normal when stockQuantity is null or < 0:
                    throw new Exception("Stock quantity must be specified for normal products.");
                case ProductType.Normal when shipmentMethod != ShipmentMethod.Post:
                    throw new Exception("Normal products can only be shipped with post.");
                case ProductType.Digital when shipmentMethod == ShipmentMethod.Post:
                    throw new Exception("Digital products can only be shipped with either a download link or e-mail.");
            }

            StockQuantity = stockQuantity;
            ShipmentMethod = shipmentMethod;
        }

        public void AddPrice(int price)
        {
            if (price < 0) throw new Exception("Price cannot be less than zero.");

            var singletonShopInstance = new Shop(); // Get from ioc container.

            foreach (var shoppingCart in singletonShopInstance.ShoppingCarts)
                if (shoppingCart.BoughtByUser != null && shoppingCart.ShoppingCartProducts.Select(x => x.Product).Any(x => x.ArticleNumber == ArticleNumber))
                    shoppingCart.BoughtByUser.Inform(new NewPriceDefinedEvent(this, price));

            Prices.Add(price);
        }

        public bool RemovePrice(int price)
        {
            if (Prices.Count == 1) throw new Exception("There must be at least one price defined for the product.");

            return Prices.Remove(price);
        }

        public void AddPicture(string url)
        {
            if (Pictures.Count == 5) throw new Exception("Maximum five pictures are allowed for product.");

            Pictures.Add(url);
        }

        public bool RemovePicture(string url)
        {
            return Pictures.Remove(url);
        }
    }
}