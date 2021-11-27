namespace Shop
{
    public class NotEnoughQuantityEvent : IDomainEvent
    {
        private readonly Product _product;

        public NotEnoughQuantityEvent(Product product)
        {
            _product = product;
        }

        public string GetEventMessage()
        {
            return $"Stock amount is not enough for {_product.Name} product.";
        }
    }
}