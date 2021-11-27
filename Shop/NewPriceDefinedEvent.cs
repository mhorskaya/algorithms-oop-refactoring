namespace Shop
{
    public class NewPriceDefinedEvent : IDomainEvent
    {
        private readonly Product _product;
        private readonly int _price;

        public NewPriceDefinedEvent(Product product, int price)
        {
            _product = product;
            _price = price;
        }

        public string GetEventMessage()
        {
            return $"New price has been defined as {_price} for product {_product.Name}.";
        }
    }
}