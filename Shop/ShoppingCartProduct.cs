namespace Shop
{
    public class ShoppingCartProduct
    {
        public Product Product { get; }

        public int Price { get; }

        public int Quantity { get; }

        public int TotalAmount => Price * Quantity;

        public ShoppingCartProduct(Product product, int price, int quantity)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString() =>
            $"Product: {Product.Name}, Article Number: {Product.ArticleNumber}, Price: {Price}, Quantity: {Quantity}, Total: {TotalAmount}";
    }
}